using Microsoft.Extensions.DependencyInjection;
using PracticumFinalCase.Application.Abstractions.RabbitMq;
using PracticumFinalCase.Application.Abstractions.Token;
using PracticumFinalCase.Infrastructure.RabbitMq;
using PracticumFinalCase.Infrastructure.Token;

namespace PracticumFinalCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();
        }
    }
}
