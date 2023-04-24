using BreweryWholesaleManagement.Models.Common;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CmsApi.Filter
{
    
        public class ModelValidationFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string actionName = filterContext.ActionDescriptor.DisplayName.ToLower();
                if (!filterContext.ModelState.IsValid)
                {
                    string errors = string.Empty;
                    foreach (var state in filterContext.ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors += string.Join(",", error.ErrorMessage);
                        }
                    }
                    //errors = string.Empty.Trim(',');
                    ContentResult content = new ContentResult();
                    content.ContentType = "application/json";
                 
                        content.Content = JsonHelper.getStatusCodeJson(MessageDescription.InvalidParameter);
                 
                filterContext.Result = content;
                    base.OnActionExecuting(filterContext);
                }
            }
        }
    }

