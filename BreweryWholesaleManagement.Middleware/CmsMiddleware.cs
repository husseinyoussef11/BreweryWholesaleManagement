using BreweryWholesaleManagement.Models.Common;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System.Diagnostics;
using System.Net;

namespace BreweryWholesaleManagement.Middleware
{
    public class CmsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CmsMiddleware> _logger;
        private Stopwatch stopwatch;
        private string IP = string.Empty;

        public CmsMiddleware(RequestDelegate next, ILogger<CmsMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Exception _ex = null;
            string RequestPath = context.Request.Path.Value;
            string jsonResponse = string.Empty;
            Stream originBody = null;


            try
            {
                if (!RequestPath.Contains("swagger"))
                {
                    RequestPath = RequestPath.Substring(context.Request.Path.Value.IndexOf("/api/"));
                    string Route = string.Empty;
                    string Controller = string.Empty;
                    string Action = string.Empty;
                    string[] str = RequestPath.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length > 0)
                        Route = str[0];
                    if (str.Length > 1)
                        Controller = str[1];
                    if (str.Length > 2)
                        Action = str[2];


                    Stream stream = context.Request.Body;
                    originBody = context.Response.Body;

                    stopwatch = new Stopwatch();
                    IP = context.Connection?.RemoteIpAddress?.ToString();

                    stopwatch.Start();

                    context.Response.Body = new MemoryStream();

                    string _originalContent = new StreamReader(stream).ReadToEnd();

                    MappedDiagnosticsLogicalContext.Set("RequestMethod", context.Request.Method);
                    MappedDiagnosticsLogicalContext.Set("RequestContentType", context.Request.ContentType);
                    MappedDiagnosticsLogicalContext.Set("RequestPath", RequestPath);
                    MappedDiagnosticsLogicalContext.Set("RequestBody", _originalContent);
                    MappedDiagnosticsLogicalContext.Set("BasePath", string.Concat(context.Request.Scheme, "://", context.Request.Host.ToUriComponent()) + context.Request.PathBase.ToUriComponent());




                    var requestContent = new StringContent(_originalContent);
                    context.Request.Body = await requestContent.ReadAsStreamAsync();
                    var newBody = new MemoryStream();
                    context.Response.Body = newBody;


                    await _next(context);
                    if (context.Response.StatusCode != (int)HttpStatusCode.OK)
                    {
                        jsonResponse = JsonHelper.getStatusCodeJson(MessageDescription.ServerError);
                    }
                    else
                    {
                        var originalResponse = context.Response.Body;
                        originalResponse.Seek(0, SeekOrigin.Begin);
                        jsonResponse = new StreamReader(originalResponse).ReadToEnd();
                    }
                }
                else
                {
                    await _next(context);
                }
            }
            catch (Exception ex)
            {
                if (RequestPath.ToLower().Contains("export"))
                    await context.Response.WriteAsync(null);

                _ex = ex;
                MappedDiagnosticsLogicalContext.Set("Exception", ex.Message + Environment.NewLine + ex.StackTrace);
                StackFrame stackFrame = new StackTrace(ex, true).GetFrame(0);
                MappedDiagnosticsLogicalContext.Set("Stacktrace", string.Join(" - ", stackFrame.GetMethod().Name, string.Concat("Line: ", stackFrame.GetFileLineNumber().ToString())));

                jsonResponse = JsonHelper.getStatusCodeJson(MessageDescription.ServerError);
            }
            finally
            {
                if (!RequestPath.Contains("swagger"))
                {
                    context.Response.Body = originBody;

                    MappedDiagnosticsLogicalContext.Set("IP", IP);
                    stopwatch.Stop();
                    MappedDiagnosticsLogicalContext.Set("ExecutionTime", stopwatch.ElapsedMilliseconds.ToString());
                    MappedDiagnosticsLogicalContext.Set("Response", jsonResponse);

                    if (_ex != null)
                        _logger.LogError($"ERROR: {_ex}");
                    else
                        _logger.LogInformation("REQUEST/RESPONSE");
                    NLog.LogManager.Flush();
                    await context.Response.WriteAsync(jsonResponse);
                }
            }
        }
    }
}