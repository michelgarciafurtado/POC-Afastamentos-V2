using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.core.ports.outbound
{
    public interface IRegrasAfastamentoRepository
    {
        Task<IEnumerable<RegraAfastamento>> ObterRegrasPorIdAsync(int tipoAfastamentoId);
    }
}
