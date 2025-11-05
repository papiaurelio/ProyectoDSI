

namespace Finanzas.Application.Models
{
    public class Email
    {
        public string To { get; set; }

        public string Subject { get; set; } = "Enviado por DDD";

        public string Body { get; set; } = "DDD";
    }
}
