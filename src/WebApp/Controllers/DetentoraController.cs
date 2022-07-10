using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DetentoraController : BaseController
    {
        public DetentoraController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
