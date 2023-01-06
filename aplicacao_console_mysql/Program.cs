
using aplicacao_console_mysql.UI;

namespace aplicacao_console_mysql;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                ================== [ MENU ] ==================
                1 - Cadastrar Cliente
                2 - Atualizar Cliente
                3 - Listar Cliente
                4 - Sair
                """);
            var opcao = Console.ReadLine();
            Console.Clear();
            switch (opcao) {
                case "1":
                    ClientesUI.Cadastrar();
                    break;
                case "2":
                    ClientesUI.Atualizar();
                    break;
                case "3":
                    ClientesUI.Listar();
                    break;
                case "4":
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.WriteLine("Opção Inválida");
                    Thread.Sleep(1200);  
                    break;
            }

        }
        
    }
}