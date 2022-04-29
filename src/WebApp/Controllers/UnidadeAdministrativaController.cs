using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UnidadeAdministrativaController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
