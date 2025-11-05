using AppFinanzas.Domain;

namespace Finanzas.Application.Contracts.Persistence
{
    public interface IPrestamoRepository : IAsyncRepository<Prestamo>
    {
        Task<IEnumerable<Prestamo>> GetPrestamosByCliente(Guid IdCliente);
    }
}
