using POC_Afastamentos_V2.core.domain.aggregates;

namespace POC_Afastamentos_V2.core.ports.outbound
{
    public interface IPolicialRepository:IGenericRepository<Policial>
    {
        Task<Policial> ObterPolicialAsync(string re);
    }
}
