namespace POC_Afastamentos_V2.core.domain.entities
{
    public class Afastamentos
    {
        public Afastamentos(int id, string name, bool ativo)
        {
            Id = id;
            Name = name;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Ativo { get; set; }


    }
}
