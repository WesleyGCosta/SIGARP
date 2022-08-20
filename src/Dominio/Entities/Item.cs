using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Item
    {
        public Item(Guid id, 
            int numeroItem, 
            int codigoAta, 
            int anoAta, 
            ETipo tipo, 
            string descricao, 
            string marca, 
            string unidadeAquisicao, 
            int quantidade, 
            decimal precoMercado, 
            decimal precoRegistrado, 
            bool ativo)
        {
            Id = id;
            NumeroItem = numeroItem;
            CodigoAta = codigoAta;
            AnoAta = anoAta;
            Tipo = tipo;
            Descricao = descricao;
            Marca = marca;
            UnidadeAquisicao = unidadeAquisicao;
            Quantidade = quantidade;
            PrecoMercado = precoMercado;
            PrecoRegistrado = precoRegistrado;
            Ativo = ativo;
        }

        public Guid Id { private set; get; }
        public int NumeroItem { get; private set; }
        public int CodigoAta { get; private set; }
        public int AnoAta { get; private set; }
        public ETipo Tipo { get; private set; }
        public string Descricao { get; private set; }
        public string Marca { get; private set; }
        public string UnidadeAquisicao { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoMercado { get; private set; }
        public decimal PrecoRegistrado { get; private set; }
        public bool Ativo { get; private set; }

        public Ata Ata { get; private set; }
        public DetentoraItem DetentoraItem { get; private set; }
        public IEnumerable<ParticipanteItem> ParticipantesItens { get; private set; }
       
    }
}
