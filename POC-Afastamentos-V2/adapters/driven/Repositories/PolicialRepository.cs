using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.adapters.driven.ConnectionDB;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.ports.outbound;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.adapters.driven.Repositories
{
    public class PolicialRepository : GenericRepository<Policial>, IPolicialRepository
    {
        public PolicialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Policial> ObterPolicialAsync(string re)
        {
            var policial = await DbSet.AsNoTracking()
                .Include(p => p.PostoGraduacao)
                .Include(p => p.Opm)
                .FirstOrDefaultAsync(p => p.Re == re);
            if (policial == null)
            {
                throw new Exception($"Policial com RE {re} não encontrado.");
            }
            return policial;
        }
    }
}
