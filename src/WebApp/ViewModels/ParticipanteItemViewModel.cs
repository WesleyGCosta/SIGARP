using System;

namespace WebApp.ViewModels
{
    public class ParticipanteItemViewModel
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid UnidadeAdministrativaId { get; set; }
        public UnidadeAdministrativaViewModel UnidadeAdministrativaViewModel { get; set; }
        public ItemViewModel ItemViewModel { get; set; }
        public ProgramacaoConsumoViewModel ProgramacaoConsumoViewModel { get; set; }
    }
}
