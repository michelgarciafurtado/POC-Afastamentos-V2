namespace POC_Afastamentos_V2.core.domain.entities
{
    public class PostoGraduacao
    {
        public int PosCod { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public int Nivel { get; set; }
        public bool Ativo { get; set; }

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
    }
}
