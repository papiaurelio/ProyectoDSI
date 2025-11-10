

using AppFinanzas.Domain.Common;
using System.Text.Json.Serialization;

namespace AppFinanzas.Domain
{
    public class Prestamo : BaseDomainModel
    {
        public Guid Cliente_Id { get; set; }

        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

        public decimal? Monto { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public decimal Cuotas { get; set; }

        public decimal Tasa_aplicada { get; set; }

        public string? Estado { get; set; }   //Enum

        public string? FrecuenciaPago { get; set; }  //Enum

        public string? TipoPrestamo { get; set; }  //Enum
    }
}
