using System.Text.Json.Serialization;

namespace WebApiLoja.DTOs
{
    public class CaixaDTO
    {
        public String caixa_id { get; set; }

        public List<String> produtos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public String? observacao { get; set; }

        public CaixaDTO() {
            produtos = new List<String>();
        }
    }
}
