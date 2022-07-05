using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UnidadeAdministrativaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Unidade ou Órgão")]
        public string NomeUnidadeAdministrativa { get; set; }
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        [Display(Name = "Admin. Direta / Indireta do Governo RO?")]
        public bool OrgaoEx { get; set; }
        [Display(Name = "Unidade da Federação")]
        public string UnidadeDaFederacao { get; set; }
        [Display(Name = "Esfera Administrativa")]
        public EhEsferaAdministrativa EsferaAdministrativa { get; set; }
        public bool Ativo { get; set; }

    }
}
