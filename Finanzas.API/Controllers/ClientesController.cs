using AppFinanzas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private static readonly List<Cliente> _clientes = new();
        private static readonly List<Prestamo> _prestamos = new();

        static ClientesController()
        {
            // Datos simulados
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

            var prestamos = new List<Prestamo>
            {
                new Prestamo
                {
                    Cliente_Id = cliente1.Id,
                    Monto = 5000,
                    fecha_inicio = DateTime.Now.AddMonths(-3),
                    Cuotas = 12,
                    Tasa_aplicada = 8.5m,
                    Estado = "Activo",
                    FrecuenciaPago = "Mensual",
                    TipoPrestamo = "Interés Simple"
                },
                new Prestamo
                {
                    Cliente_Id = cliente2.Id,
                    Monto = 3000,
                    fecha_inicio = DateTime.Now.AddMonths(-1),
                    Cuotas = 6,
                    Tasa_aplicada = 7.2m,
                    Estado = "Activo",
                    FrecuenciaPago = "Mensual",
                    TipoPrestamo = "Interés Compuesto"
                }
            };

            cliente1.Prestamos = prestamos.Where(p => p.Cliente_Id == cliente1.Id).ToList();
            cliente2.Prestamos = prestamos.Where(p => p.Cliente_Id == cliente2.Id).ToList();

            _clientes.AddRange([cliente1, cliente2]);
            _prestamos.AddRange(prestamos);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes() => Ok(_clientes);


        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound(new { message = "Cliente no encontrado" });

            return Ok(cliente);
        }


        [HttpGet("{id}/prestamos")]
        public ActionResult<IEnumerable<Prestamo>> GetPrestamosPorCliente(Guid id)
        {
            var prestamos = _prestamos.Where(p => p.Cliente_Id == id).ToList();
            if (!prestamos.Any())
                return NotFound(new { message = "No se encontraron préstamos para este cliente" });

            return Ok(prestamos);
        }
    }
}
