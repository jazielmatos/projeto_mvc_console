using negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao_console_mysql.UI
{
    internal class ClientesUI
    {
        public static void Cadastrar()
        {
            
            Console.Clear();
            Cliente cliente = new Cliente();
            Console.WriteLine("========== [ CADASTRO DE CLIENTES ] ============");
            Console.WriteLine("Digite o Nome: ");
            cliente.Nome = Console.ReadLine().Trim();
            Console.WriteLine("Digite o Email: ");
            cliente.Email = Console.ReadLine().Trim();
            cliente.Salvar();
            MensagensUI.Mensagens("Cliente Cadastrada Com Sucesso!");
        }

        internal static void Atualizar()
        {
            Console.Clear();
            Console.WriteLine("========== [ ATUALIZAR CLIENTE ] ============");
            Console.WriteLine("Digite o ID ou Email Do Cliente: ");
            var IDouEmail = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(IDouEmail))
            {
                MensagensUI.Mensagens("Digite o Id ou Email",1400);
                ClientesUI.Atualizar();
                return;
            }
            else
            {
                
                var clientes = Cliente.BuscarPorIDouEmail(IDouEmail);
                if(clientes.Count() > 0)
                {
                    foreach (var cliente in clientes)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Id: {0}",cliente.Id);
                        Console.WriteLine("Nome: {0}", cliente.Nome);
                        Console.WriteLine("Email: {0}", cliente.Email);
                        Console.WriteLine("========================\n");

                    }

                }
                else
                {
                    MensagensUI.Mensagens("Cliente não localizado!!", 2000);
                    ClientesUI.Atualizar();
                    return;
                }

                Console.WriteLine("Digite o Id do Cliente para editar: ");
                var id = int.Parse(Console.ReadLine());
                var clienteDb = Cliente.BuscaPorId(id);
                if(clienteDb == null)
                {
                    MensagensUI.Mensagens("Cliente não existe");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("Id: {0}", clienteDb.Id);
                    Console.WriteLine("Nome: {0}", clienteDb.Nome);
                    Console.WriteLine("Email: {0}", clienteDb.Email);
                    Console.WriteLine("========================\n");
                    Console.WriteLine("Digite o Novo Nome: ");
                    var novoNome = Console.ReadLine().Trim();
                    Console.WriteLine("Digite o Novo Email: ");
                    var novoEmail= Console.ReadLine().Trim();
                    Cliente.Editar(id,novoNome,novoEmail);
                }
            }
        }

        internal static void Listar()
        {
            Console.Clear();
            var clientes = Cliente.ListarClientes();
            if (clientes.Count() > 0)
                {
                    foreach (var cliente in clientes)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Id: {0}", cliente.Id);
                        Console.WriteLine("Nome: {0}", cliente.Nome);
                        Console.WriteLine("Email: {0}", cliente.Email);
                        Console.WriteLine("========================\n");

                    }
                    Console.WriteLine("Aperte Enter para voltar");
                    Console.ReadLine();
                }
                else
                {
                    MensagensUI.Mensagens("Nenhum cliente localizado!!", 2000);
                }
            }
    }
}
