using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JRJ.Modas
{

    public class ClientesUI
    {
        public static void GerenciarClientes()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar clientes");
                Console.WriteLine("2 - Cadastrar cliente");
                Console.WriteLine("3 - Alterar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        CadastrarCliente();
                        break;
                    case "3":
                        AlterarCliente();
                        break;
                    case "4":
                        ExcluirCliente();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        private static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("Lista de clientes:");
            foreach (var cliente in ClienteModel.clientes)
            {
                Console.WriteLine($"ID: {cliente.ClienteID} | Nome Completo: {cliente.NomeCompleto} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        private static void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de cliente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            var proximoID = ClienteModel.clientes.Max((e) => e.ClienteID) + 1;

            ClienteModel cliente = new ClienteModel
            {
                ClienteID = proximoID ?? 1,
                Nome = nome,
                Sobrenome = sobrenome,
                Endereco = endereco,
                Telefone = telefone
            };
            ClienteModel.clientes.Add(cliente);
            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        private static void AlterarCliente()
        {
            Console.Clear();
            Console.WriteLine("Alterar cliente");

            Console.Write("Digite o ID do cliente que deseja alterar: ");
            long id = long.Parse(Console.ReadLine());

            ClienteModel cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);

            if (ClienteModel.clientes == null)
            {
                throw new Exception("Cliente não encontrado!");
            }

            Console.Write($"Digite o novo nome ({cliente.Nome}): ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o novo sobrenome ({cliente.Sobrenome}): ");
            string sobrenome = Console.ReadLine();

            Console.Write($"Digite o novo endereço({cliente.Endereco}): ");
            string endereco = Console.ReadLine();

            Console.Write($"Digite o novo telefone ({cliente.Telefone}): ");
            string telefone = Console.ReadLine();

            cliente.Nome = nome;
            cliente.Sobrenome = sobrenome;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
            Console.WriteLine("Cliente alterado com sucesso!");
        }

        private static void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("Excluir cliente");

            Console.Write("Informe o ID do cliente que deseja excluir: ");
            long id = long.Parse(Console.ReadLine());

            ClienteModel cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);
            
            if(cliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }

            ClienteModel.clientes.Remove(cliente);
        }

        //        private static void RealizarVenda()
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Realizar venda:");

        //            // Seleciona um cliente existente ou cadastra um novo
        //            ClienteModel cliente = SelecionarCliente();

        //            // Cria uma nova venda
        //            VendaModel venda = new VendaModel();
        //            venda.Cliente = cliente;
        //            venda.VendaID = proximoIdVenda;
        //            ;

        //            bool continuar = true;
        //            do
        //            {
        //                Console.Clear();
        //                Console.WriteLine($"Venda nº {venda.VendaID} - Cliente: {venda.Cliente.Nome}");
        //                Console.WriteLine();
        //                ProdutoUI.ListarProdutos();

        //                Console.WriteLine();
        //                Console.WriteLine("Digite o ID do produto que deseja comprar (0 para finalizar):");
        //                int idProduto = int.Parse(Console.ReadLine());

        //                if (idProduto == 0)
        //                {
        //                    // Finaliza a venda
        //                    venda.Total = venda.Itens.Sum(i => i.Subtotal);
        //                    vendas.Add(venda);
        //                    Console.WriteLine($"Venda finalizada. Total: R${venda.Total}");
        //                    continuar = false;
        //                }
        //                else
        //                {
        //                    // Seleciona o produto a ser comprado
        //                    ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);
        //                    if (produto == null)
        //                    {
        //                        Console.WriteLine("Produto não encontrado!");
        //                    }
        //                    else
        //                    {
        //                        // Pede a quantidade desejada
        //                        Console.WriteLine($"Digite a quantidade de {produto.Nome} que deseja comprar:");
        //                        int quantidade = int.Parse(Console.ReadLine());



        //                        // Adiciona o item à venda
        //                        ItemVenda item = new ItemVenda();
        //                        item.Id = venda.Itens.Count + 1;
        //                        item.Produto = produto;
        //                        item.Quantidade = quantidade;
        //                        item.PrecoUnitario = produto.Preco;
        //                        venda.Itens.Add(item);

        //                        Console.WriteLine($"{quantidade} {produto.Nome} adicionado(s) à venda!");

        //                    }
        //                }

        //                Console.WriteLine();
        //                Console.WriteLine("Pressione qualquer tecla para continuar...");
        //                Console.ReadKey();
        //            } while (continuar);
        //        }

        //        private static ClienteModel SelecionarCliente()
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Selecione o cliente:");
        //            foreach (var cliente in ClienteModel.clientes)
        //            {
        //                Console.WriteLine($"ID: {cliente.ClienteID} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
        //            }
        //            Console.Write("Digite o ID do cliente ou 0 para voltar: ");
        //            int idCliente;
        //            while (!int.TryParse(Console.ReadLine(), out idCliente) || (idCliente != 0 && !Program.clientes.Exists(c => c.Id == idCliente)))
        //            {
        //                Console.WriteLine("ID inválido! Digite novamente...");
        //                Console.Write("Digite o ID do cliente ou 0 para voltar: ");
        //            }
        //            if (idCliente == 0)
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                return ClienteModel.clientes.Find(c => c.ClienteID == idCliente);
        //            }
        //        }
    }
}