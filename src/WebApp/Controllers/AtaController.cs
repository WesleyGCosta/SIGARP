using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AtaController : BaseController
    {
        public AtaController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public async Task<IActionResult> Create(AtaViewModel ataViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Atencao"] = "Algo de Errado não está certo";
                return View("Cadastrar", ataViewModel);
            }

            TempData["Sucesso"] = "Cadastrado com Sucesso";

            return View("Cadastrar");
        }

        public IActionResult IncluirDetentora() => View();
        public IActionResult IncluirParticipante() => View();
    }
}
