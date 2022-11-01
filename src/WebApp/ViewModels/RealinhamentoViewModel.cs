using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebApp.ViewModels.CustomValidation;

namespace WebApp.ViewModels
{
    public class RealinhamentoViewModel
    {
        public RealinhamentoViewModel()
        {
            Id = Guid.NewGuid();
            DataRegistro = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Novo Preço de Mercado")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal PrecoMercado { get; set; }

        [Display(Name = "Preço Registrado")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MoreThan(nameof(PrecoMercado), ErrorMessage = "O {0} não pode ser maior que Preço de Mercado")]
        public decimal PrecoRegistrado { get; set; }

        [Display(Name = "Justificativa")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(250, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres e máxima de {1}.", MinimumLength = 10)]
        public string Justificativa { get; set; }
    }
}
