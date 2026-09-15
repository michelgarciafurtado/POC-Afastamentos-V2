using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.adapters.driven.Repositories;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.adapters.driven.ConnectionDB
{
    public static class RegistryDb
    {
        public static IServiceCollection RegistryDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("WorkConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPolicialRepository, PolicialRepository>();
            services.AddScoped<ISolicitarAfastamentoRepository, SolicitarAfastamentoRepository>();

            return services;
        }
    }
}
