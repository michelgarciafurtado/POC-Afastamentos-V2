using POC_Afastamentos_V2.core.Dtos.PostoGraduacao;

namespace POC_Afastamentos_V2.core.ports.inbound
{
    public interface IPostoGraduacaoUseCase
    {
        Task<int> CriarAsync(NovoPostoGraduacaoDto dto);
        Task<IEnumerable<PostoGraduacaoDto>> ListarAsync(FiltroPostoGraduacaoDto dto);
        Task<PostoGraduacaoDto> ObterAsync(int postoGraduacaoCod);
        Task<PostoGraduacaoDto> AtualizarAsync(AlterarPostoGraduacaoDto dto);
        Task<bool> ExcluirAsync(int postoGraduacaoCod);
        Task<bool> AlterarStatusAsync(int postoGraduacaoCod, bool ativo);
        Task<IEnumerable<PostoGraduacaoDto>> ObterTodosAsync(); 
    }
}
