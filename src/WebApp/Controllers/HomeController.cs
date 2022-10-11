using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Detentoras;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchAta _searchAta;
        private readonly SearchDetentora _searchDetentora;
        private readonly SearchUnidadeAdministrativa _searchUnidadeAdministrativa;

        public HomeController(ILogger<HomeController> logger,
            IAtaRepository ataRepository,
            IDetentoraRepository detentoraRepository,
            IUnidadeAdministrativaRepository unidadeAdministrativaRepository,
            INotifier notifier) : base(notifier)
        {
            _logger = logger;
            _searchAta = new(ataRepository);
            _searchDetentora = new(detentoraRepository);
            _searchUnidadeAdministrativa = new(unidadeAdministrativaRepository);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AtasPublicada = await _searchAta.CountAtasByPublish(publish: true);
            ViewBag.Pendentes = await _searchAta.CountAtasByPublish(publish: false);
            return View();
        }

        public IActionResult Notification() => ViewComponent("Summary");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
