using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Opms;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.UseCases;

public class OpmUseCase : IOpmUseCase
{
    private readonly IGenericRepository<Opm> _opmRepository;

    public OpmUseCase(IGenericRepository<Opm> opmRepository)
    {
        _opmRepository = opmRepository;
    }

    public async Task<bool> AlterarStatus(AlterarStatusOpmDto dto)
    {
        var listOpm = await _opmRepository.BuscarAsync(o => o.OpmCod == dto.OpmCod);
        if (listOpm == null || !listOpm.Any())
            throw new InvalidOperationException("Opm não encontrada");
        var Opm = listOpm.First();
        if(dto.Ativo == true)
            Opm.AtivarOpm();
        else
            Opm.InativarOpm();
        _opmRepository.Atualizar(Opm);
        var sucesso = await _opmRepository.CommitAsync();
        return sucesso >= 1;
    }

    public async Task<OpmDto> AtualizarAsync(AlterarOpmDto dto)
    {
        var listOpm = await _opmRepository.BuscarAsync(o => o.OpmCod == dto.OpmCod);
        if (listOpm == null || !listOpm.Any())
            throw new InvalidOperationException("Opm não encontrada");

        var Opm = listOpm.First();
        
        Opm.AtualizarOpm(
            dto.OpmCod,
            dto.NomeOpm,
            dto.OpmNivel,
            dto.LocalOpm
        );
        
        _opmRepository.Atualizar(Opm);
        var sucesso = await _opmRepository.CommitAsync();
        if (sucesso < 1)
            throw new InvalidOperationException("Erro ao atualizar Opm");

        return new OpmDto(Opm.OpmCod, Opm.NomeOpm, Opm.OpmNivel, Opm.LocalOpm, Opm.Ativo); 
    }

    public async Task<int> CriarAsync(NovaOpmDto dto)
    {
       Opm opm = new Opm(dto.OpmCod,dto.NomeOpm,dto.OpmNivel,dto.LocalOpm);
        await _opmRepository.AdicionarAsync(opm);
        var sucesso = await _opmRepository.CommitAsync();
        if(sucesso <1) throw new InvalidOperationException("Erro ao criar Opm");
        return sucesso;
    }

    public async Task<IEnumerable<OpmDto>> ListarAsync(FiltroOpmDto opmDto)
    {
        IQueryable<Opm> query = _opmRepository.Queryable();

        if (!string.IsNullOrEmpty(opmDto.OpmCod))
            query = query.Where(o => o.OpmCod.Contains(opmDto.OpmCod));

        if (!string.IsNullOrEmpty(opmDto.NomeOpm))
            query = query.Where(o => o.NomeOpm.Contains(opmDto.NomeOpm));
        if (opmDto.OpmNivel.HasValue)
        {
            query = query.Where(o =>
                o.OpmNivel == opmDto.OpmNivel.Value);
        }

        if (!string.IsNullOrWhiteSpace(opmDto.LocalOpm))
        {
            query = query.Where(o =>
                o.LocalOpm.Contains(opmDto.LocalOpm));
        }

        if (opmDto.Ativo.HasValue)
        {
            query = query.Where(o =>
                o.Ativo == opmDto.Ativo.Value);
        }

        var Opms = await query.ToListAsync();

        if(Opms == null || !Opms.Any())
            throw new InvalidOperationException("Nenhuma Opm encontrada");

        return Opms.Select(o => new OpmDto(o.OpmCod, o.NomeOpm, o.OpmNivel, o.LocalOpm, o.Ativo));
    }

    public async Task<OpmDto> ObterAsync(string opmCod)
    {
        var Opms = await _opmRepository.BuscarAsync(o => o.OpmCod == opmCod);
        if(Opms == null || !Opms.Any())
            throw new InvalidOperationException("Opm não encontrada");
        return new OpmDto(Opms.First().OpmCod, Opms.First().NomeOpm, Opms.First().OpmNivel, Opms.First().LocalOpm, Opms.First().Ativo);
    }

    public async Task<IEnumerable<OpmDto>> ObterTodosAsync()
    {
        var Opms = await _opmRepository.ObterTodosAsync();
        if(Opms == null || !Opms.Any())
            throw new InvalidOperationException("Nenhuma Opm encontrada");
        return Opms.Select(o => new OpmDto(o.OpmCod, o.NomeOpm, o.OpmNivel, o.LocalOpm, o.Ativo));
    }
}
