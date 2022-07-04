using Microsoft.Extensions.DependencyInjection;
using ValidarContaBancaria.Service.Interfaces;
using ValidarContaBancaria.Service.Services;

namespace ValidarContaBancaria.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service
                .AddScoped<IBancoDoBrasilService, BancoDoBrasilService>()
                .AddScoped<ISantanderService, SantanderService>()
                .AddScoped<ICaixaService, CaixaService>()
                .AddScoped<IBradescoService, BradescoService>()
                .AddScoped<IItauService, ItauService>();

            return service;
        }
    }
}
