using System;
using System.Collections.Generic;
using JRJ.Modas;

namespace JRJ.Modas
{
    public class CategoriaUI { 

        public static void MenuDeFuncionalidades()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar categorias");
                Console.WriteLine("2 - Cadastrar categoria");
                Console.WriteLine("3 - Alterar categoria");
                Console.WriteLine("4 - Excluir categoria");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarCategorias();
                        break;
                    case "2":
                        CadastrarCategoria();
                        break;
                    case "3":
                        AlterarCategoria();
                        break;
                    case "4":
                        ExcluirCategoria();
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

        private static void CadastrarCategoria()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de categoria:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Descricao: ");
            string descricao = Console.ReadLine();
            var proximoID = CategoriaModel.categorias.Max((e) => e.CategoriaID) + 1;
            CategoriaModel categoria = new CategoriaModel
            {
                CategoriaID = proximoID ?? 1,
                CategoriaIDGUID = Guid.NewGuid(),
                Nome = nome,
                Descricao = descricao
            };
            CategoriaModel.categorias.Add(categoria);


            Console.WriteLine();
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }

        private static void ListarCategorias()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias:");
            foreach (var categoria in CategoriaModel.categorias)
            {
                Console.WriteLine($"ID: {categoria.CategoriaID} | Guid: {categoria.CategoriaIDGUID} | Nome: {categoria.Nome}");
            }
        }

        private static void AlterarCategoria()
        {
            Console.Clear();
            Console.WriteLine("Alteração de categoria:");
            Console.Write("Digite o ID da categoria que deseja alterar: ");
            long id = long.Parse(Console.ReadLine());
            CategoriaModel categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }
            
            Console.Write($"Novo nome para a categoria {categoria.Nome}: ");
            string nome = Console.ReadLine();
            categoria.Nome = nome;

            Console.WriteLine();
            Console.WriteLine("Categoria alterada com sucesso!");
        }

        private static void ExcluirCategoria()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de categoria:");
            Console.Write("Digite o ID da categoria que deseja excluir: ");
            long id = long.Parse(Console.ReadLine());
            CategoriaModel categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }

            if (ProdutoModel.produtos.Exists(p => p.Categoria.CategoriaID == id))
            {
                throw new Exception("Não é possível excluir a categoria, pois existem produtos vinculados a ela!");
            }

            CategoriaModel.categorias.Remove(categoria);

            Console.WriteLine();
            Console.WriteLine("Categoria excluída com sucesso!");
        }
    }
}




