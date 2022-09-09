﻿using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class UnidadeAdministrativaController : BaseController
    {
        private readonly CreateUnidadeAdministrativa _createUnidadeAdministrativa;
        public UnidadeAdministrativaController(
            IUnidadeAdministrativaRepository unidadeAdministrativaRepository,
            INotifier notifier) : base(notifier)
        {
            _createUnidadeAdministrativa = new CreateUnidadeAdministrativa(unidadeAdministrativaRepository);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnidadeAdministrativaViewModel unidadeAdministrativaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(unidadeAdministrativaViewModel);
            }

            var unidadeAdministrativa = UnidadeAdministrativaFactory.ToEntityUnidadeAdministrativa(unidadeAdministrativaViewModel);

            await _createUnidadeAdministrativa.Run(unidadeAdministrativa);

            TempData["Success"] = "Unidade Administrativa Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }
    }
}
