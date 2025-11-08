using AppFinanzas.Domain;
using MediatR;


namespace Finanzas.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<Guid>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        //public DateTime FechaIngreso { get; set; }
        public decimal Calificacion { get; set; } = 5.0m;
    }
}
