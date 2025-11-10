using System;

namespace Finanzas.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public string EntityName { get; }

        public object Key { get; }

        public int ErrorCode { get; } = 404;
        public NotFoundException(string entityName, object key)
            : base($"No se encontró la entidad \"{entityName}\" con identificador ({key}).")
        {
            EntityName = entityName;
            Key = key;
        }

        public NotFoundException(string message, string? entityName = null, object? key = null)
            : base(message)
        {
            EntityName = entityName ?? "Desconocida";
            Key = key ?? "N/A";
        }
    }
}
