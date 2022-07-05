using System;

namespace Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public Guid DetentoraId { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Uf { get; private set; }
        public string Municipio { get; private set; }

        public Detentora Detentora { get; private set; }

    }
}
