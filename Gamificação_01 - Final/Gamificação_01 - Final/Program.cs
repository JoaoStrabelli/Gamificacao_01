﻿using System;
using System.Collections.Generic;
using JRJ.Modas;

namespace JRJ.Modas
{
    public class Program
    {

        static void Main(string[] args)
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Gerenciar produtos");
                Console.WriteLine("2 - Gerenciar categorias");
                Console.WriteLine("3 - Gerenciar clientes");
                Console.WriteLine("4 - Realizar venda");
                Console.WriteLine("5 - Mostrar relatório de vendas");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ProdutoUI.GerenciarProdutos();
                        break;
                    case "2":
                        CategoriaUI.MenuDeFuncionalidades();
                        break;
                    case "3":
                        ClientesUI.GerenciarClientes();
                        break;
                    case "4":
                        VendaUI.RealizarVenda();
                        break;
                    case "5":
                        //RelatorioUI.MostrarRelatorioVendas();
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




    }
}