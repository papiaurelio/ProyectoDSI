using MediatR;


namespace Finanzas.Application.Features.Prestamos.Queries.GetPrestamosList
{
    public class GetPrestamosListQuery : IRequest<List<PrestamosVm>>
    {
        public Guid _IdUsuario { get; set; } = Guid.Empty;

        public GetPrestamosListQuery(Guid idusuario)
        {
            if (idusuario == Guid.Empty)
                throw new ArgumentException("Problemas al identificar el usuario.", nameof(idusuario));

            _IdUsuario = idusuario;
        }
    }
}
