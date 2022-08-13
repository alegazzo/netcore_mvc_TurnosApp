using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int Id {get; set; }

        public string Descripcion {get; set; }
    }
}