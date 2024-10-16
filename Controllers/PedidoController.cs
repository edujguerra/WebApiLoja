using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using WebApiLoja.DTOs;

namespace WebApiLoja.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize()]
    public class PedidoController : ControllerBase
    {
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GeraListaPedidos([FromBody] JsonElement entrada)
        {
            PedidoDTO pedidos = JsonSerializer.Deserialize<PedidoDTO>(entrada);

            return Ok(pedidos);
        }
    }
}
