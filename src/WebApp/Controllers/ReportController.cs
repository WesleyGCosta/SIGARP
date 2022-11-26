using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;

namespace WebApp.Controllers
{
    [Authorize]
    public class ReportController : BaseController
    {
        private readonly SearchAta _searchAta;
        public ReportController(IAtaRepository ataRepository, INotifier notifier) : base(notifier)
        {
            _searchAta = new SearchAta( ataRepository);
        }

        public IActionResult Generate()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        public async Task<IActionResult> GetAtaReport(int yearAta, int codeAta)
        {
            var ata = await _searchAta.GetAtaPublish(yearAta, codeAta, true);

            var ataViewModel = AtaFactory.ToViewModel(ata);

            return PartialView("_ReportAtaDetails", ataViewModel);
        }
    }
}
