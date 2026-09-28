using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using POC_Afastamentos_V2.core.UseCases;
using POC_Afastamentos_V2.core.UseCases.validations;
using POC_Afastamentos_V2.core.UseCases.validations.strategies;

namespace POC_Afastamentos_V2.adapters.drivin.DI
{
    public static class RegistryUseCases
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAfastamentoUseCase, AfastamentoUseCase>();
            services.AddScoped<ISolicitarAfastamentoUseCase, SolicitarAfastamentoUseCase>();
            services.AddScoped<IOpmUseCase, OpmUseCase>();
            services.AddScoped<IPostoGraduacaoUseCase, PostoGraduacaoUseCase>();
            services.AddScoped<IValidadorAfastamentoStrategy, ValidadorDispensaServicoStrategy>();
            services.AddScoped<IValidadorAfastamentoStrategy, ValidadorLutoStrategy>();
            services.AddScoped<IRegraAfastamentoUseCase, RegraAfastamentoUseCase>();


            return services;
        }
    }
}
