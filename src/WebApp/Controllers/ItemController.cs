using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
