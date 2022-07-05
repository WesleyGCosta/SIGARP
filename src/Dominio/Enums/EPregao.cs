using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum EPregao
    {
        [Display(Name = "Pregão Eletrônico")] PregaoEletronico,
        [Display(Name = "Pregão Presencial")] PregaoPresencial,
        [Display(Name = "Ambos Pregões")] AmbosPregaos
    }
}
