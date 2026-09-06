namespace POC_Afastamentos_V2.core.domain.entities
{
    public class Afastamentos
    {
        public Afastamentos(int id, string nome, bool ativo)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }


    }
}
