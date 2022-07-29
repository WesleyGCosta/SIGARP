using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Detentoras;
using Historia.Enderecos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class DetentoraController : BaseController
    {
        private readonly CreateDetentora _createDetentora;
        private readonly CreateEndereco _createEndereco;
        public DetentoraController(
            IDetentoraRepository detentoraRepository,
            IEnderecoRepository enderecoRepository,
            INotifier notifier) : base(notifier)
        {
            _createDetentora = new CreateDetentora(detentoraRepository);
            _createEndereco = new CreateEndereco(enderecoRepository);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetentoraViewModel detentoraViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(detentoraViewModel);
            }

            var detentora = DetentoraFactory.ToEntityDetentora(detentoraViewModel);
            var endereco = EnderecoFactory.ToEntityEndereco(detentoraViewModel.Endereco, detentoraViewModel.Id);

            await _createDetentora.Run(detentora);
            await _createEndereco.Run(endereco);

            TempData["Success"] = "Detentora Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }
    }
}
