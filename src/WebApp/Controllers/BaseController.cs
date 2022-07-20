using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        public List<int> LoadDropYear()
        {
            DateTime dataInicio = Convert.ToDateTime("01/01/2011");
            DateTime hoje = DateTime.Now;
            DateTime dataPosterior;

            var years = new List<int>();
            int j = 0;

            int qtdAnos = hoje.Year - dataInicio.Year;
            qtdAnos++;

            for (int i = 0; i < qtdAnos; i++)
            {
                dataPosterior = dataInicio.AddYears(j);
                years.Add(dataPosterior.Year);
                j++;
            }

            return years;
        }
    }
}
