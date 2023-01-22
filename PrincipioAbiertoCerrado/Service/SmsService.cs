using Newtonsoft.Json.Linq;
using PrincipiosSOLID.PrincipioAbiertoCerrado.Interface;

namespace PrincipiosSOLID.PrincipioAbiertoCerrado.Service
{
    public class SmsService : INotification
    {
        private string MobileNumber { get; set; }

        private string Message { get; set; }

        public SmsService(string mobileNumber, string message)
        {
            MobileNumber = mobileNumber;
            Message = message;
        }

        public async Task<JObject> SendNotification()
        {
            await Task.Delay(500);
            return new JObject()
            {
                ["Codigo"] = "01",
                ["Descripcion"] = $"Se ha enviado un sms a número {MobileNumber}"

            };
        }
    }
}
