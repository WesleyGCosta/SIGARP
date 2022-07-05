using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ETipo
    {
        [Display(Name = "Material")] Material,
        [Display(Name = "Serviço")] Servico
    }
}
