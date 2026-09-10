using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.UseCases;

namespace POC_Afastamentos_V2.adapters.drivin.DI
{
    public static class RegistryUseCases
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAfastamentoUseCase, AfastamentoUseCase>();
            services.AddScoped<ISolicitarAfastamentoUseCase, SolicitarAfastamentoUseCase>();
            services.AddScoped<IOpmUseCase, OpmUseCase>();

            return services;
        }
    }
}
