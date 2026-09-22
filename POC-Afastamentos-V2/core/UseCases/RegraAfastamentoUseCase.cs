using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Opms;
using POC_Afastamentos_V2.core.Dtos.Regras;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using POC_Afastamentos_V2.core.UseCases.validations;

namespace POC_Afastamentos_V2.core.UseCases;

public class RegraAfastamentoUseCase : IRegraAfastamentoUseCase
{
    private readonly IGenericRepository<RegraAfastamento> _regraAfastRepository;

    public RegraAfastamentoUseCase(IGenericRepository<RegraAfastamento> regraAfastRepository)
    {
        _regraAfastRepository = regraAfastRepository;
    }

    public async Task<bool> AlterarStatus(AlterarRegraDto dto)
    {
        var list = await _regraAfastRepository.BuscarAsync(r => r.Id == dto.Id);
        if (list == null || !list.Any())
            throw new InvalidOperationException("Regra não encontrada");

        var regra = list.First();
        if (regra.TipoAfastamento != null)
        {
            regra.TipoAfastamento.Ativo = !regra.TipoAfastamento.Ativo;
        }
        else
        {
            throw new InvalidOperationException("Não é possível alterar status da regra sem o tipo de afastamento carregado");
        }

        _regraAfastRepository.Atualizar(regra);
        var sucesso = await _regraAfastRepository.CommitAsync();
        return sucesso >= 1;
    }

    public async Task<OpmDto> AtualizarAsync(AlterarRegraDto dto)
    {
        var list = await _regraAfastRepository.BuscarAsync(r => r.Id == dto.Id);
        if (list == null || !list.Any())
            throw new InvalidOperationException("Regra não encontrada");

        var regra = list.First();
        regra.TipoAfastamentoId = dto.TipoAfastamentoId;
        regra.TipoRegra = dto.TipoRegra;
        regra.Valor = dto.Valor;
        regra.Frequencia = dto.Frequencia;
        regra.DiasMinimo = dto.DiasMinimo ?? 0;
        regra.DiasMaximo = dto.DiasMaximo ?? 0;
        regra.qtd = dto.qtd ?? 0;

        _regraAfastRepository.Atualizar(regra);
        var sucesso = await _regraAfastRepository.CommitAsync();
        if (sucesso < 1) throw new InvalidOperationException("Erro ao atualizar regra");

        return new OpmDto(regra.Id.ToString(), regra.TipoRegra, 0, regra.Frequencia ?? string.Empty, true);
    }

    public async Task<int> CriarAsync(NovaRegraDto dto)
    {
        var regra = new RegraAfastamento
        {
            TipoAfastamentoId = dto.TipoAfastamentoId,
            TipoRegra = dto.TipoRegra,
            Valor = dto.Valor,
            Frequencia = dto.Frequencia,
            DiasMinimo = dto.DiasMinimo ?? 0,
            DiasMaximo = dto.DiasMaximo ?? 0,
            qtd = dto.qtd ?? 0
        };

        await _regraAfastRepository.AdicionarAsync(regra);
        var sucesso = await _regraAfastRepository.CommitAsync();
        if (sucesso < 1) throw new InvalidOperationException("Erro ao criar regra");
        return sucesso;
    }

    public async Task<IEnumerable<RegraDto>> ListarAsync(FiltroRegraDto opmDto)
    {
        var query = _regraAfastRepository.Queryable();

        if (opmDto.tipoAfastamentoId > 0)
            query = query.Where(r => r.TipoAfastamentoId == opmDto.tipoAfastamentoId);

        if (!string.IsNullOrWhiteSpace(opmDto.tipoRegra))
            query = query.Where(r => r.TipoRegra.Contains(opmDto.tipoRegra));

        var regras = await query.Include(r => r.TipoAfastamento).ToListAsync();
        if (regras == null || !regras.Any())
            throw new InvalidOperationException("Nenhuma Regra encontrada");

        return regras.Select(r => new RegraDto(
            r.Id,
            r.TipoAfastamentoId,
            r.TipoAfastamento?.Nome ?? string.Empty,
            r.TipoRegra,
            r.Valor,
            r.Frequencia,
            r.DiasMinimo,
            r.DiasMaximo,
            r.qtd
        ));
    }

    public async Task<RegraDto> ObterAsync(int RegraId)
    {
        var list = await _regraAfastRepository.BuscarAsync(r => r.Id == RegraId);
                            
        if (list == null || !list.Any())
            throw new InvalidOperationException("Regra não encontrada");
        var regra = list.First();
        return new RegraDto(regra.Id,regra.TipoAfastamentoId,regra.TipoAfastamento.Nome, regra.TipoRegra, regra.Valor,regra.Frequencia, regra.DiasMinimo, regra.DiasMaximo, regra.qtd);
    }

    public async Task<IEnumerable<RegraDto>> ObterTodosAsync()
    {
        var regras = await _regraAfastRepository.ObterTodosAsync();
        if (regras == null || !regras.Any())
            throw new InvalidOperationException("Nenhuma Regra encontrada");

        return regras.Select(r => new RegraDto(
            r.Id,
            r.TipoAfastamentoId,
            r.TipoAfastamento?.Nome ?? string.Empty,
            r.TipoRegra,
            r.Valor,
            r.Frequencia,
            r.DiasMinimo,
            r.DiasMaximo,
            r.qtd
        ));
    }
}
