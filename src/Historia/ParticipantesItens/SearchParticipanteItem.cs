﻿using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.ParticipantesItens
{
    public class SearchParticipanteItem
    {
        private readonly IParticipanteItemRepository _participanteItemRepository;

        public SearchParticipanteItem(IParticipanteItemRepository participanteItemRepository)
        {
            _participanteItemRepository = participanteItemRepository;
        }

        public async Task<ParticipanteItem> GetByIds(Guid unidadeAdministrativaId, Guid itemId)
        {
            return await _participanteItemRepository.GetParticipanteItemByIds(unidadeAdministrativaId, itemId);
        }

        public async Task<ParticipanteItem> GetByParticipanteId(Guid participanteId)
        {
            return await _participanteItemRepository.GetByParticipanteId(participanteId);
        }

        public async Task<IEnumerable<ParticipanteItem>> GetListByAta(int yearAta, int codeAta)
        {
            return await _participanteItemRepository.GetListByAta(yearAta, codeAta);
        }

        public async Task<IEnumerable<ParticipanteItem>> GetListByUnidadeAdministrativaIdAndYearAta(Guid unidadeAdministrativaId, int yearAta)
        {
            return await _participanteItemRepository.GetListByUnidadeAdministrativaIdAndYearAta(unidadeAdministrativaId, yearAta);
        }

        public async Task<IEnumerable<ParticipanteItem>> GetListOrdemFornecimentoByUnidadeAdministrativaIdAndYearAta(Guid unidadeAdministrativaId, int yearAta)
        {
            return await _participanteItemRepository.GetListOrdemFornecimentoByUnidadeAdministrativaIdAndYearAta(unidadeAdministrativaId, yearAta);
        }
    }
}
