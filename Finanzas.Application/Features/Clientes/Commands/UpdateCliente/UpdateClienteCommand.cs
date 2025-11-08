
using MediatR;

namespace Finanzas.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

    }
}
