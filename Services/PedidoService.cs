using Microsoft.AspNetCore.Mvc.Formatters;
using WebApiLoja.DTOs;
using WebApiLoja.Models;

namespace WebApiLoja.Services
{
    public class PedidoService
    {

        private const int Caixa1_Altura = 30;
        private const int Caixa1_Largura = 40;
        private const int Caixa1_Comprimento = 80;
        private const int Caixa1_Volume = 30 * 40 * 80;

        private const int Caixa2_Altura = 80;
        private const int Caixa2_Largura = 50;        
        private const int Caixa2_Comprimento = 40;
        private const int Caixa2_Volume = 80 * 50 * 40;

        private const int Caixa3_Altura = 50;
        private const int Caixa3_Largura = 80;
        private const int Caixa3_Comprimento = 60;
        private const int Caixa3_Volume = 50 * 80 * 60;

        private int totalCaixa1 = 0;
        private int totalCaixa2 = 0;
        private int totalCaixa3 = 0;

        public List<PedidoCaixasDTO> retornaPacotes(List<Pedido> pedidos)
        {
            List<PedidoCaixasDTO> listaPedidoCaixa = new List<PedidoCaixasDTO>();

            foreach (Pedido pedido in pedidos)
            {
                PedidoCaixasDTO pedidoCaixa = new PedidoCaixasDTO();
                pedidoCaixa.pedido_id = pedido.pedido_id;

                CaixaDTO caixa = new CaixaDTO();
                totalCaixa1 = 0;
                totalCaixa2 = 0;
                totalCaixa3 = 0;

                foreach (Produto produto in pedido.produtos)
                {
                    int nrCaixa = verificaDimensoes(produto);
                    if (nrCaixa != 0) { 
                        caixa.caixa_id = "Caixa " + nrCaixa.ToString();
                        if (nrCaixa == 1)
                        {
                            totalCaixa1 += produto.dimensoes.altura 
                                * produto.dimensoes.largura 
                                * produto.dimensoes.comprimento;
                        }
                        else if (nrCaixa == 2)
                        {
                            totalCaixa2 += produto.dimensoes.altura 
                                * produto.dimensoes.largura 
                                * produto.dimensoes.comprimento ;
                        }
                        else if (nrCaixa == 3)
                        {
                            totalCaixa3 += produto.dimensoes.altura 
                                * produto.dimensoes.largura 
                                * produto.dimensoes.comprimento ;
                        }
                    } else
                    {
                        caixa.caixa_id = null;
                        caixa.observacao = "Produto não cabe em nenhum tipo de caixa.";
                    }
                    caixa.produtos.Add(produto.produto_id);                    
                }
                pedidoCaixa.caixas.Add(caixa);
                listaPedidoCaixa.Add(pedidoCaixa);
            }

            return listaPedidoCaixa;
        }

        private int verificaDimensoes(Produto produto)
        {
            if (produto.dimensoes.altura <= Caixa1_Altura &&
                produto.dimensoes.largura <= Caixa1_Largura &&
                produto.dimensoes.comprimento <= Caixa1_Comprimento &&
                    (produto.dimensoes.comprimento * 
                    produto.dimensoes.largura * 
                    produto.dimensoes.altura) + totalCaixa1 <= Caixa1_Volume)
            {
                return 1;
            }
            else if (produto.dimensoes.altura <= Caixa2_Altura &&
                produto.dimensoes.largura <= Caixa2_Largura &&
                produto.dimensoes.comprimento <= Caixa2_Comprimento &&
                    (produto.dimensoes.comprimento *
                    produto.dimensoes.largura *
                    produto.dimensoes.altura) + totalCaixa2 <= Caixa2_Volume)
            {
                return 2;
            }
            else if (produto.dimensoes.altura <= Caixa3_Altura &&
                produto.dimensoes.largura <= Caixa3_Largura &&
                produto.dimensoes.comprimento <= Caixa3_Comprimento &&
                    (produto.dimensoes.comprimento *
                    produto.dimensoes.largura *
                    produto.dimensoes.altura) + totalCaixa3 <= Caixa3_Volume)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
