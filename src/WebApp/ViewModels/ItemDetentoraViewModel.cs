using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ItemDetentoraViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Código da Ata")]
        public int CodigoAta { get; set; }

        [Display(Name = "Ano da Ata")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AnoAta { get; set; }

        [Display(Name = "Item")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid CodigoItem { get; set; }

        [Display(Name = "Detentora")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid CodigoDetentora { get; set; }

        public ItemViewModel Item { get; set; }
        public DetentoraViewModel Detentora { get; set; }
    }
}
