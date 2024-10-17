using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using WebApiLoja.DTOs;
using WebApiLoja.Services;

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
            EntradaDTO json = JsonSerializer.Deserialize<EntradaDTO>(entrada);

            PedidoService pedidoService = new PedidoService();
            List<PedidoCaixasDTO> pedidoCaixa = pedidoService.retornaPacotes(json.pedidos);
            
            SaidaDTO saidaDTO  = new SaidaDTO();
            saidaDTO.pedidos = pedidoCaixa;

            return Ok(saidaDTO);
        }
    }
}
