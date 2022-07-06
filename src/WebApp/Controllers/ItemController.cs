using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ItemController : BaseController
    {
        public ItemController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        
    }
}
