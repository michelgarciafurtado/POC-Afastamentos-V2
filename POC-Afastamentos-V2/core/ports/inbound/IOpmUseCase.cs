namespace POC_Afastamentos_V2.core.ports.inbound;

public interface IOpmUseCase
{
    Task ObterOpmAsync(string OpmCod);
}
