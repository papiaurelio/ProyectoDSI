using AutoMapper;
using Finanzas.Application.Contracts.Persistence;
using MediatR;

namespace Finanzas.Application.Features.Prestamos.Queries.GetPrestamosList
{
    public class GetPrestamosListQueryHandler : IRequestHandler<GetPrestamosListQuery, List<PrestamosVm>>
    {

        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMapper _mapper;

        public GetPrestamosListQueryHandler(IPrestamoRepository prestamoRepository, IMapper mapper)
        {
            _prestamoRepository = prestamoRepository;
            _mapper = mapper;
        }

        public async Task<List<PrestamosVm>> Handle(GetPrestamosListQuery request, CancellationToken cancellationToken)
        {
            var prestamosList = await _prestamoRepository.GetPrestamosByCliente(request._IdUsuario);

            return _mapper.Map<List<PrestamosVm>>(prestamosList);
        }
    }
}
