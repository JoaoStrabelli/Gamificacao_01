using JRJ.Modas;
using System;
using System.Collections.Generic;


namespace JRJ.Modas
{
    public class ProdutoUI
    {

        public static void GerenciarProdutos()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar produtos");
                Console.WriteLine("2 - Cadastrar produto");
                Console.WriteLine("3 - Alterar produto");
                Console.WriteLine("4 - Excluir produto");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarProdutos();
                        break;
                    case "2":
                        CadastrarProduto();
                        break;
                    case "3":
                        AlterarProduto();
                        break;
                    case "4":
                        ExcluirProduto();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        private static void ListarProdutos()
        {
            Console.Clear();
            Console.WriteLine("Lista de produtos:");
            foreach (var produto in ProdutoModel.produtos)
            {
                Console.WriteLine($"ID: {produto.ProdutoID} | Nome: {produto.Nome} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
            }
        }



        private static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de produto:");

            var proximoID = ProdutoModel.produtos.Max((e) => e.ProdutoID) + 1;

            ProdutoModel produto = new ProdutoModel();

            produto.ProdutoID = proximoID ?? 1;
           
            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            double preco;
            while (true)
            {
                Console.Write("Preço: ");
                try
                {
                    preco = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Preço inválido. Digite um valor numérico válido.");
                }
            }
            produto.Preco = preco;

            int idCategoria;
            while (true)
            {
                Console.Write("ID da categoria: ");
                try
                {
                    idCategoria = int.Parse(Console.ReadLine());
                   
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ID inválido. Digite um valor numérico válido.");
                }
            }

            
            produto.Categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);

            if (produto.Categoria == null)
            {
                Console.WriteLine("Categoria não encontrada.");
            }
            else
            {
                ProdutoModel.produtos.Add(produto);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
        }

        private static void AlterarProduto()
        {
            Console.Clear();
            Console.WriteLine("Alteração de produto:");

            Console.Write("ID do produto: ");
            long idProduto = long.Parse(Console.ReadLine());

            ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);

            if (produto != null)
            {
                Console.Write($"Nome ({produto.Nome}): ");
                string nome = Console.ReadLine();
                if (!string.IsNullOrEmpty(nome))
                {
                    produto.Nome = nome;
                }

                Console.Write($"Preço ({produto.Preco}): ");
                string precoStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(precoStr))
                {
                    produto.Preco = double.Parse(precoStr);
                }

                Console.Write($"ID da categoria ({produto.Categoria.CategoriaID}): ");
                string idCategoriaStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(idCategoriaStr))
                {
                    long idCategoria = long.Parse(idCategoriaStr);
                    produto.Categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);
                }

                Console.WriteLine("Produto alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        private static void ExcluirProduto()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de produto:");

            Console.Write("ID do produto: ");
            long idProduto = long.Parse(Console.ReadLine());

            ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);

            if (produto != null)
            {
                ProdutoModel.produtos.Remove(produto);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }
    }
}
