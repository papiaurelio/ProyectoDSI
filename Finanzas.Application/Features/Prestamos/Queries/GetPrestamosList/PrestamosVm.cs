

namespace Finanzas.Application.Features.Prestamos.Queries.GetPrestamosList
{
    public class PrestamosVm
    {
        public Guid Cliente_Id { get; set; }

        public decimal? Monto { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public decimal Cuotas { get; set; }

        public decimal Tasa_aplicada { get; set; }

        public string? Estado { get; set; }   //Enum
    }
}
