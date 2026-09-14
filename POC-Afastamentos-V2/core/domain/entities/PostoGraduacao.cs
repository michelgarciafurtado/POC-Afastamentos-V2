namespace POC_Afastamentos_V2.core.domain.entities
{
    public class PostoGraduacao
    {
        public int PosCod { get; private set; }
        public string Sigla { get; private set; }
        public string Descricao { get; private set; }
        public int Nivel { get; private set; }
        public bool Ativo { get; private set; }

        public PostoGraduacao( string sigla, string descricao, int nivel)
        {
            
            Sigla = sigla;
            Descricao = descricao;
            Nivel = nivel;
            Ativo = true;
        }

        public PostoGraduacao(int posCod, string sigla, string descricao, int nivel)
        {
            PosCod = posCod;
            Sigla = sigla;
            Descricao = descricao;
            Nivel = nivel;
            Ativo = true;
        }

        public void InativarPosto()
        {
            Ativo = false;
        }
        public void AtivarPosto()
        {
            Ativo = true;
        }
    }
}
