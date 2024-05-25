using System;
using System.Collections.Generic;

namespace CadastroClientes
{
    class Program
    {
        // Lista estática para armazenar os clientes
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            // Variável para controlar o loop do menu
            bool executando = true;

            // Loop do menu principal
            while (executando)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Visualizar clientes");
                Console.WriteLine("3 - Editar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("5 - Sair");

                // Lê a opção escolhida pelo usuário
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        executando = false; // Encerra o loop do menu
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        // Método para adicionar um cliente
        static void AdicionarCliente()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do cliente: ");
            string email = Console.ReadLine();

            // Cria um novo cliente com os dados fornecidos
            Cliente cliente = new Cliente(nome, email);

            // Adiciona o cliente à lista de clientes
            clientes.Add(cliente);

            Console.WriteLine("Cliente adicionado com sucesso.");
        }

        // Método para visualizar todos os clientes
        static void VisualizarClientes()
        {
            // Percorre a lista de clientes e exibe os dados de cada um
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("Nome: " + cliente.Nome);
                Console.WriteLine("E-mail: " + cliente.Email);
                Console.WriteLine("----------------------");
            }
        }

        // Método para editar um cliente
        static void EditarCliente()
        {
            Console.WriteLine("Digite o nome do cliente que deseja editar: ");
            string nome = Console.ReadLine();

            // Encontra o cliente na lista pelo nome
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            if (cliente != null)
            {
                Console.WriteLine("Digite o novo nome do cliente: ");
                string novoNome = Console.ReadLine();

                Console.WriteLine("Digite o novo e-mail do cliente: ");
                string novoEmail = Console.ReadLine();

                // Atualiza os dados do cliente
                cliente.Nome = novoNome;
                cliente.Email = novoEmail;

                Console.WriteLine("Cliente editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        // Método para excluir um cliente
        static void ExcluirCliente()
        {
            Console.WriteLine("Digite o nome do cliente que deseja excluir: ");
            string nome = Console.ReadLine();

            // Encontra o cliente na lista pelo nome
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            if (cliente != null)
            {
                // Remove o cliente da lista
                clientes.Remove(cliente);
                Console.WriteLine("Cliente excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }

    // Classe Cliente que representa os dados de um cliente
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
