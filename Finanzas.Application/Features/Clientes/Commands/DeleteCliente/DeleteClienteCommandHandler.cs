using AppFinanzas.Domain;
//using AutoMapper;
using Finanzas.Application.Contracts.Persistence;
using Finanzas.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finanzas.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        //private readonly Mapper _mapper;
        private ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository, ILogger<DeleteClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            //_mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _clienteRepository.GetByIdAsync(request.Id);

            if (clienteToDelete == null)
            {
                _logger.LogError($"Cliente con id {request.Id} no encontrado.");
                throw new NotFoundException(nameof(Cliente), request.Id);
            }


            await _clienteRepository.DeleteAsync(clienteToDelete.Id);

            _logger.LogInformation($"Cliente con id {request.Id} eliminado exitosamente.");

        }
    }
}
