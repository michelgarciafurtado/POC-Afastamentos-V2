using POC_Afastamentos_V2.core.domain.entities;

namespace POC_Afastamentos_V2.core.domain.aggregates
{
    public class Policial
    {
        public string Re { get; private set; }
        public int Dg { get; private set; }
        public string Nome { get; private set; }
        public int PosCod { get; private set; }
        public PostoGraduacao PostoGraduacao { get; private set; }
        public string OpmCod { get; private set; }
        public Opm Opm { get; private set; }

        public Policial(string re, int dg, string nome, int posCod, PostoGraduacao postoGraduacao, string opmCod, Opm opm)
        {
            Re = re;
            Dg = dg;
            Nome = nome;
            PosCod = posCod;
            PostoGraduacao = postoGraduacao;
            OpmCod = opmCod;
            Opm = opm;
        }

        public Policial(string re, int dg, string nome, int posCod, string opmCod)
        {
            Re = re;
            Dg = dg;
            Nome = nome;
            PosCod = posCod;
            OpmCod = opmCod;
        }
         

       
    }
}
