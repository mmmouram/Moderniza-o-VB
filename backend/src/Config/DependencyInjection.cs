using Backend.Repositories;
using Backend.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Config
{
    public static class DependencyInjectionConfig
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            // Registra a camada de serviços
            services.AddScoped<IPedidoService, PedidoService>();
            
            // Registra a camada de repositórios
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
