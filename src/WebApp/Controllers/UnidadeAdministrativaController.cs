using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UnidadeAdministrativaController : BaseController
    {
        public UnidadeAdministrativaController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
