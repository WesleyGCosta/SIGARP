using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class ReportController : BaseController
    {
        public ReportController(INotifier notifier) : base(notifier)
        {
        }

        public IActionResult Generate()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }
    }
}
