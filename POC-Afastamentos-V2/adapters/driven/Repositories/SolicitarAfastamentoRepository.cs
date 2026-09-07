using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.adapters.driven.ConnectionDB;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.adapters.driven.Repositories;

public class SolicitarAfastamentoRepository(ApplicationDbContext context, DbSet<SolicitacaoAfastamento> dbSet) : GenericRepository<SolicitacaoAfastamento>(context), ISolicitarAfastamentoRepository
{
}
