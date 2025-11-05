
using AppFinanzas.Domain.Common;

namespace AppFinanzas.Domain
{
    public class Cliente : BaseDomainModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        //public DateTime FechaIngreso { get; set; }
        public Decimal Calificacion { get; set; }
        public ICollection<Prestamo>? Prestamos { get; set; }
    }
}
