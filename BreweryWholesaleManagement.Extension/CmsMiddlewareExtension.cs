using BreweryWholesaleManagement.Middleware;
using Microsoft.AspNetCore.Builder;

namespace BreweryWholesaleManagement.Extension
{
    public static class CmsMiddlewareExtension
    {
        public static IApplicationBuilder UseCmsMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CmsMiddleware>();
        }
    }
}