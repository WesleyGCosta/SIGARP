using Domain.Entities;
using System;

namespace WebApp.Factories
{
    public static class ParticipanteItemFactory
    {
        public static ParticipanteItem ToEntity(Guid participanteId, Guid itemId, Guid unidadeAdministrativaId)
        {
            return new ParticipanteItem(participanteId, itemId, unidadeAdministrativaId);
        }
    }
}
