using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

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
            return PartialView("_ReportAtaDetails", await GetAtaMap(yearAta, codeAta));
        }

        public async Task<IActionResult> GeneratePdf(int yearAta, int codeAta)
        {
            var ataViewModel = await GetAtaMap(yearAta, codeAta);
            var customSwitches = "--header-spacing 15 --footer-font-size 10 --footer-center  \" Emitido em : " + DateTime.Now + " - SIGARP \n  Sistema de Gerenciamento de Atas de Registro de Preço  [page]-[toPage] \"  --footer-spacing 8 ";
            var view = new ViewAsPdf
            {
                Model = ataViewModel,
                ViewName = "DespachoFinal",
                PageSize = Size.A4,
                IsGrayScale = false,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(10, 1, 20, 1),
                CustomSwitches = customSwitches,
                PageHeight = 630,
                PageWidth = 300

            };

            return view;
        }

        private async Task<AtaViewModel> GetAtaMap(int yearAta, int codeAta)
        {
            var ata = await _searchAta.GetAtaPublish(yearAta, codeAta, true);

            var ataViewModel = AtaFactory.ToViewModel(ata);
            return ataViewModel;
        }
    }
}
