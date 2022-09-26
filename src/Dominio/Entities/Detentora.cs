using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Detentora
    {
        public Detentora(Guid id, string cnpj, string razaoSocial, string nomeFantasia, string email, string telefone, EPessoa pessoa)
        {
            Id = id;
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Email = email;
            Telefone = telefone;
            Pessoa = pessoa;
        }

        public Guid Id { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public EPessoa Pessoa { get; private set; }

        public IEnumerable<DetentoraItem> DetentorasItens { get; private set; }
        public IEnumerable<Endereco> Enderecos { get; private set; }

        public void Update(Detentora detentora)
        {
            RazaoSocial = detentora.RazaoSocial;
            NomeFantasia = detentora.NomeFantasia;
            Email = detentora.Email;
            Telefone = detentora.Telefone;
            Pessoa = detentora.Pessoa;
        }
    }
}
