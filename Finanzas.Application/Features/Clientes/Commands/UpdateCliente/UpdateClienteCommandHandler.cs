using AppFinanzas.Domain;
using AutoMapper;
using Finanzas.Application.Contracts.Persistence;
using Finanzas.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finanzas.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly Mapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, Mapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToUpdate = await _clienteRepository.GetByIdAsync(request.Id);

            if (clienteToUpdate == null)
            {
                _logger.LogError($"El cliente con Id: {request.Id} no fue encontrado");
                throw new NotFoundException(nameof(Cliente), request.Id);
            }

            _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

            await _clienteRepository.UpdateAsync(clienteToUpdate);

            _logger.LogInformation($"El cliente con Id: {request.Id} fue actualizado exitosamente");

        }
    }
}
