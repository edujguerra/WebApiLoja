using System.Text.Json.Serialization;
using WebApiLoja.Models;

namespace WebApiLoja.DTOs
{
    public class PedidoCaixasDTO
    {
        public int pedido_id {  get; set; }
        
        public List<CaixaDTO> caixas { get; set; }

    public PedidoCaixasDTO()
        {
            caixas = new List<CaixaDTO>();
        }
    }
}
