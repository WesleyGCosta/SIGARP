using System.ComponentModel.DataAnnotations;

namespace Dominio.Enums
{
    public enum EPregao
    {
        [Display(Name = "Pregão Eletônico")] PregaoEletronico,
        [Display(Name = "Pregão Presencial")] PregaoPresencial,
        [Display(Name = "Ambos Pregões")] AmbosPregaos
    }
}
