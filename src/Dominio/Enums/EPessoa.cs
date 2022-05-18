using System.ComponentModel.DataAnnotations;

namespace Dominio.Enums
{
    public enum EPessoa
    {
        [Display(Name = "Jurídico")] Juridica,
        [Display(Name = "Física")] Fisica
    }
}
