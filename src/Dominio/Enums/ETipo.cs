using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    public enum ETipo
    {
        [Display(Name = "Material")] Material,
        [Display(Name = "Serviço")] Servico
    }
}
