using AppFinanzas.Domain;
using AutoMapper;
using Finanzas.Application.Contracts.Infrastructure;
using Finanzas.Application.Contracts.Persistence;
using Finanzas.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finanzas.Application.Features.Clientes.Commands
{
    public class ClienteComandHandler : IRequestHandler<ClienteComand, Guid>
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<ClienteComandHandler> _logger;

        public ClienteComandHandler(IClienteRepository clienteRepository, 
            IMapper mapper, IEmailService emailService, ILogger<ClienteComandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(ClienteComand request, CancellationToken cancellationToken)
        {
            var clienteEntity = _mapper.Map<Cliente>(request);
            var nuevoCliente = await _clienteRepository.AddAsync(clienteEntity);

            _logger.LogInformation($"Cliente {nuevoCliente.Id} fue creado correctamente.");

            await SendEmail(nuevoCliente);
            return nuevoCliente.Id;
        }


        private async Task SendEmail(Cliente cliente)
        {
            var email = new Email
            {
                To = cliente.Email,
                Subject = "Bienvenido.",
                Body = "Cliente creado correctamente"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al enviar el email.");
            }
            
        }
    }
}
