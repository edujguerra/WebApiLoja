using WebApiLoja.Models;

namespace WebApiLoja.DTOs
{
    public class EntradaDTO
    {       
        public List<Pedido> pedidos { get; set; }

        public EntradaDTO()
        {
            pedidos = new List<Pedido>();
        }
    }
}
