using Dominio.Enums;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Detentora
    {
        public Guid Id { get; private set; }
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

        public IEnumerable<DetentoraItem> DetentorasItens { get; private set; }
    }
}
