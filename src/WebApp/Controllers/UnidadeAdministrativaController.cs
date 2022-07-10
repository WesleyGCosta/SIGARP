using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UnidadeAdministrativaController : BaseController
    {
        public UnidadeAdministrativaController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(UnidadeAdministrativaViewModel unidadeAdministrativaViewModel)
        {
            return View(unidadeAdministrativaViewModel);
        }
    }
}
