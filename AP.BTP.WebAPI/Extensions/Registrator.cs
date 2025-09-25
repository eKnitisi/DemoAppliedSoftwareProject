using AP.BTP.WebAPI.Middleware;
using System.Security.Cryptography.X509Certificates;

namespace AP.BTP.WebAPI.Extensions
{
    public static class Registrator
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}
