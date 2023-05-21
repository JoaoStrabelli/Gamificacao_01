using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JRJ.Modas
{
    public class VendaUI
    {
        public static void RealizarVenda()
        {
            Console.Clear();
            Console.WriteLine("Realizar venda:");

            // Seleciona um cliente existente ou cadastra um novo
            ClienteModel cliente = SelecionarCliente();

            // Cria uma nova venda
            VendaModel venda = new VendaModel();
            venda.Cliente = cliente;
            venda.VendaID = proximoIdVenda;

            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Venda nº {venda.Id} - Cliente: {venda.Cliente.Nome}");
                Console.WriteLine();
                ListarProdutos();

                Console.WriteLine();
                Console.WriteLine("Digite o ID do produto que deseja comprar (0 para finalizar):");
                int idProduto = int.Parse(Console.ReadLine());

                if (idProduto == 0)
                {
                    // Finaliza a venda
                    venda.Total = venda.Itens.Sum(i => i.Subtotal);
                    vendas.Add(venda);
                    Console.WriteLine($"Venda finalizada. Total: R${venda.Total}");
                    continuar = false;
                }
                else
                {
                    // Seleciona o produto a ser comprado
                    ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);
                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado!");
                    }
                    else
                    {
                        // Pede a quantidade desejada
                        Console.WriteLine($"Digite a quantidade de {produto.Nome} que deseja comprar:");
                        int quantidade = int.Parse(Console.ReadLine());



                        // Adiciona o item à venda
                        ItemVenda item = new ItemVenda();
                        item.Id = venda.Itens.Count + 1;
                        item.Produto = produto;
                        item.Quantidade = quantidade;
                        item.PrecoUnitario = produto.Preco;
                        venda.Itens.Add(item);

                        Console.WriteLine($"{quantidade} {produto.Nome} adicionado(s) à venda!");

                    }
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        private static ClienteModel SelecionarCliente()
        {
            Console.Clear();
            Console.WriteLine("Selecione o cliente:");
            foreach (var cliente in ClienteModel.clientes)
            {
                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
            }
            Console.Write("Digite o ID do cliente ou 0 para voltar: ");
            int idCliente;
            while (!int.TryParse(Console.ReadLine(), out idCliente) || (idCliente != 0 && !clientes.Exists(c => c.Id == idCliente)))
            {
                Console.WriteLine("ID inválido! Digite novamente...");
                Console.Write("Digite o ID do cliente ou 0 para voltar: ");
            }
            if (idCliente == 0)
            {
                return null;
            }
            else
            {
                return clientes.Find(c => c.Id == idCliente);
            }
        }
    }

}