using AppFinanzas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private static readonly List<Cliente> _clientes;
        private static readonly List<Prestamo> _prestamos;

        static PrestamosController()
        {

            var cliente1 = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = "Byron",
                Apellido = "Samayoa",
                Telefono = "8888-9999",
                Email = "byron@correo.com",
                Direccion = "Managua, Nicaragua",
                Calificacion = 4.8m
            };

            var cliente2 = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = "Ana",
                Apellido = "López",
                Telefono = "7777-4444",
                Email = "ana@correo.com",
                Direccion = "León, Nicaragua",
                Calificacion = 4.5m
            };

            _clientes = new List<Cliente> { cliente1, cliente2 };

            _prestamos = new List<Prestamo>
            {
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    Cliente_Id = cliente1.Id,
                    Monto = 5000,
                    fecha_inicio = DateTime.Now.AddMonths(-3),
                    Cuotas = 12,
                    Tasa_aplicada = 8.5m,
                    Estado = "Activo",
                    FrecuenciaPago = "Mensual",
                    TipoPrestamo = "Interés Simple",
                    Cliente = cliente1
                },
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    Cliente_Id = cliente2.Id,
                    Monto = 3000,
                    fecha_inicio = DateTime.Now.AddMonths(-1),
                    Cuotas = 6,
                    Tasa_aplicada = 7.2m,
                    Estado = "Activo",
                    FrecuenciaPago = "Mensual",
                    TipoPrestamo = "Interés Compuesto",
                    Cliente = cliente2
                }
            };

            cliente1.Prestamos = _prestamos.Where(p => p.Cliente_Id == cliente1.Id).ToList();
            cliente2.Prestamos = _prestamos.Where(p => p.Cliente_Id == cliente2.Id).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prestamo>> GetPrestamos() => Ok(_prestamos);

        [HttpGet("{id}")]
        public ActionResult<Prestamo> GetPrestamo(Guid id)
        {
            var prestamo = _prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo == null)
                return NotFound(new { message = "Préstamo no encontrado" });

            return Ok(prestamo);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<Prestamo>> GetPrestamosPorCliente(Guid clienteId)
        {
            var prestamosCliente = _prestamos.Where(p => p.Cliente_Id == clienteId).ToList();
            if (!prestamosCliente.Any())
                return NotFound(new { message = "No se encontraron préstamos para este cliente" });

            return Ok(prestamosCliente);
        }
    }
}
