using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifier _notifier;

        protected BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }
    }
}
