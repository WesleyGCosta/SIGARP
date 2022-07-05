using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
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

        public IEnumerable<DetentoraItem> DetentorasItens { get; private set; }
        public IEnumerable<Endereco> Enderecos { get; private set; }
    }
}
