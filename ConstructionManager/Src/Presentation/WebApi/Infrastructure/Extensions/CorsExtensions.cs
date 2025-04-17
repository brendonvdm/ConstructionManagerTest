using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Infrastructure.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddAnyCors(this IServiceCollection services)
        {
            return services.AddCors(x =>
            {
                x.AddPolicy("Any", b =>
                {
                    b.SetIsOriginAllowed(_ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials();
                });
            });
        }
        public static IApplicationBuilder UseAnyCors(this IApplicationBuilder app)
        {
            return app.UseCors("Any");
        }
    }
}
