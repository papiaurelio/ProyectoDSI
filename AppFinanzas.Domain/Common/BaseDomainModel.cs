using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanzas.Domain.Common
{
    //Solo como referencia
    public abstract class BaseDomainModel 
    {
        public Guid Id { get; set; }
        public DateTime? FechaCreacion { get; set; }
        //public string? CreadoPor { get; set; }
        public DateTime? FechaUltimaModific { get; set; }
        //public string? ActualizadoPor { get; set; }

    }
}
