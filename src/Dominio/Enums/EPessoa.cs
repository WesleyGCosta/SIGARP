using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum EPessoa
    {
        [Display(Name = "Jurídico")] Juridica,
        [Display(Name = "Física")] Fisica
    }
}
