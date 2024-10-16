using WebApiLoja.Models;

namespace WebApiLoja.DTOs
{
    public class PedidoDTO
    {       
        public List<Pedido> pedidos { get; set; }

        public PedidoDTO()
        {
            pedidos = new List<Pedido>();
        }
    }
}
