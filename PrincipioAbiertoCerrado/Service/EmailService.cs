using Newtonsoft.Json.Linq;
using PrincipiosSOLID.PrincipioAbiertoCerrado.Interface;

namespace PrincipiosSOLID.PrincipioAbiertoCerrado.Service
{
    public class EmailService : INotification
    {
        private string Email { get; set; }

        private string Body { get; set; }

        private string From { get; set; }

        public EmailService()
        {
        }

        public EmailService(string email, string body, string from)
        {
            Email = email;
            Body = body;
            From = from;
        }

        public async Task<JObject> SendNotification()
        {
            await Task.Delay(500);
            return new JObject()
            {
                ["Codigo"] = "01",
                ["Descripcion"] = $"Se ha enviado el correo a {Email}"

            };
        }
    }
}
