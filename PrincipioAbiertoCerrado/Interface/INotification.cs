using Newtonsoft.Json.Linq;

namespace PrincipiosSOLID.PrincipioAbiertoCerrado.Interface
{
    public interface INotification
    {
        Task<JObject> SendNotification();
    }
}
