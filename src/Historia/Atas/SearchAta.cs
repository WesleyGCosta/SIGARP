﻿using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.Atas
{
    public class SearchAta
    {
        private readonly IAtaRepository _ataRepository;

        public SearchAta(IAtaRepository ataRepository)
        {
            _ataRepository = ataRepository;
        }

        public async Task<Ata> GetAtaByYear(int year)
        {
            return await _ataRepository.GetByYear(year);
        }
    }
}