namespace POC_Afastamentos_V2.core.domain.entities
{
    public class Opm
    {
        public string OpmCod { get; set; }
        public string NomeOpm { get; set; }
        public int OpmNivel { get; set; }
        public string LocalOpm { get; set; }
        public bool Ativo { get; set; }

        public Opm(string opmCod, string nomeOpm, int opmNivel, string localOpm)
        {
            OpmCod = opmCod;
            NomeOpm = nomeOpm;
            OpmNivel = opmNivel;
            LocalOpm = localOpm;
            Ativo = true;
        }

        public Opm(string opmCod, string nomeOpm)
        {
            OpmCod = opmCod;
            NomeOpm = nomeOpm;
        }

        public void AlterarNome(string novoNome)
        {
            NomeOpm = novoNome;
        }
        public void InativarOpm()
        {
            Ativo = false;
        }
        public void AtivarOpm()
        {
            Ativo = true;
        }
    }
}
