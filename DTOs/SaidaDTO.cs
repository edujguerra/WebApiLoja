using WebApiLoja.Models;

namespace WebApiLoja.DTOs
{
    public class SaidaDTO
    {

        public List<PedidoCaixasDTO> pedidos { get; set; }

        public SaidaDTO()
        {
            pedidos = new List<PedidoCaixasDTO>();
        }
    }
}
