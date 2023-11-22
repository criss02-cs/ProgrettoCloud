using Microsoft.AspNetCore.Mvc;
using ProgettoCloud.Model;
using ProgettoCloud.Service;

namespace ProgettoCloud.Blazor.Controllers;

[ApiController, Route("[controller]")]
public class CheckVatController : ControllerBase
{
    private readonly CheckVatService _client;

    public CheckVatController(CheckVatService client)
    {
        _client = client;
        ModelState.ClearValidationState(nameof(RequestDto));
    }
    
    [HttpPost, Route("Check")]
    public async Task<ActionResult> CheckVat([FromBody] RequestDto body)
    {
        if (!TryValidateModel(body, nameof(RequestDto)))
        {
            // Estrai tutti i messaggi di errore e uniscili in una sola stringa
            var errorMessages = string.Join(", ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            // Restituisci la stringa degli errori
            return Ok(errorMessages);
        }
        var response = await _client.CheckVat(body);
        return Ok(response);
    }
}