using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Application.Services;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register application services
            services.AddScoped<ProjectTaskService>();
            services.AddScoped<ProjectService>();

            return services;
        }
    }
}
