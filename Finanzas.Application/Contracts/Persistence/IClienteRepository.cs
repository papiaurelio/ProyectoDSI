
using AppFinanzas.Domain;

namespace Finanzas.Application.Contracts.Persistence
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesByUsuario(Guid IdUsuario); //Usuario todavia no implementado.

    }
}
