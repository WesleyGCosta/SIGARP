using Dominio.Enums;

namespace Dominio.Entidades
{
    public class Detentora
    {
        public int Id { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public EPessoa Pessoa { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Uf { get; private set; }
        public string Municipio { get; private set; }

        public Item Item { get; private set; }
    }
}
