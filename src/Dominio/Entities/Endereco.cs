using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Endereco
    {
        public Endereco(Guid id, Guid detentoraId, string cep, string rua, int numero, string bairro, EUnidadeFederacao uf, string municipio)
        {
            Id = id;
            DetentoraId = detentoraId;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Uf = uf;
            Municipio = municipio;
        }

        public Guid Id { get; private set; }
        public Guid DetentoraId { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public EUnidadeFederacao Uf { get; private set; }
        public string Municipio { get; private set; }

        public Detentora Detentora { get; private set; }

    }
}
