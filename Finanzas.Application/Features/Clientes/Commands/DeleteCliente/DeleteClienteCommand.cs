using MediatR;

namespace Finanzas.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest
    {
        public Guid Id { get; set; } 
    }
}
