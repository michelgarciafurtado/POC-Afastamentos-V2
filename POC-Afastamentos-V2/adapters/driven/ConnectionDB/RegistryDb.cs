using Microsoft.EntityFrameworkCore;

namespace POC_Afastamentos_V2.adapters.driven.ConnectionDB
{
    public static class RegistryDb
    {
        public static IServiceCollection RegistryDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicaDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
