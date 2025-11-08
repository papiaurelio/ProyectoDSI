
using AppFinanzas.Domain;
using AutoMapper;
using Finanzas.Application.Features.Clientes.Commands.CreateCliente;
using Finanzas.Application.Features.Prestamos.Queries.GetPrestamosList;

namespace Finanzas.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Prestamo, PrestamosVm>();
            CreateMap<CreateClienteCommand, Cliente>();
        }
    }
}
