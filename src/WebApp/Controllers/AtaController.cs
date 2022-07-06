using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult IncluirDetentora() => View();
        public IActionResult IncluirParticipante() => View();
    }
}
