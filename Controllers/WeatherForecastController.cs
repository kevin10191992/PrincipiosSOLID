using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PrincipiosSOLID.PrincipioAbiertoCerrado.Interface;
using PrincipiosSOLID.PrincipioAbiertoCerrado.Service;

namespace PrincipiosSOLID.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  

    private readonly ILogger<WeatherForecastController> _logger;
    

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    [HttpGet("Notificar/")]
    public async Task<IActionResult> NotificarUsuario(string? email = "", string? Telefono = "")
    {


        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(Telefono))
        {

            return BadRequest();
        }

        List<INotification> listaNotificaciones = new List<INotification>();

        if (!string.IsNullOrEmpty(email))
        {

            listaNotificaciones.Add(new EmailService(email, "hola mundo", "yo"));

        }

        if (!string.IsNullOrEmpty(Telefono))
        {
            listaNotificaciones.Add(new SmsService(Telefono, "hola mundo"));
        }


        return Ok(
                    await Notificar(listaNotificaciones)
            );

    }


    private async Task<JObject> Notificar(List<INotification> Notificaciones)
    {
        JObject res = new JObject();
        JArray ListResp = new JArray();
        foreach (var item in Notificaciones)
        {
            ListResp.Add(await item.SendNotification());
        }

        res["Codigo"] = "01";
        res["Descripcion"] = "OK";

        res["Respuestas"] = ListResp;

        return res;
    }
}
