using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao_console_mysql.UI
{
    internal class MensagensUI
    {
        public static void Mensagens(string mensagem, int timer = 2000) { 
            Console.Clear();
            Console.Write(mensagem);
            Thread.Sleep(timer);    
            Console.Clear();
        }
    }
}
