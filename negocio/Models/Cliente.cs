using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace negocio.Models
{
    public class Cliente
    {
        public int Id { get; set; } = default!;
        public string? Nome { get; set; } 
        public string? Email { get; set; }

        public static readonly string? conexao = Environment.GetEnvironmentVariable("CODIGO_MYSQL"); //na duvidade reinicia a IDE

        public void Salvar()
        {

            //if(conexao == null)  conexao = "Server=localhost;User ID=root;Password=;Database=atividade_mysql";
            using (var conn = new MySqlConnection(conexao)) {
               
                /*try
                {
                    conn.Open();
                    Console.WriteLine("Conexao aberta");
                    conn.Close();
                    Console.WriteLine("Conexao fechada");

                }
                catch { 

                    Console.WriteLine("Conexao falhada");

                }*/
                conn.Open();
                var query = $"insert into clientes values(null,'{this.Nome}','{this.Email}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();  
                conn.Close();
                //conn.Dispose(); -> using ja faz o dispose pro garbascolector(sla) -> utiliza o using pois quando finalizar, ele ja fecha a conexao com o BD 
            }

        }
        public static List<Cliente> BuscarPorIDouEmail(string IDouEmail)
        {
            var clientes = new List<Cliente>();
            using (var conn = new MySqlConnection(conexao)) {
                conn.Open();
                var query = $"select * from clientes where id='{IDouEmail}' or email like '%{IDouEmail}%';";
                var command = new MySqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        Nome = dataReader["nome"].ToString(),
                        Email = dataReader["email"].ToString()

                    });
                }
                conn.Close();
            }
            return clientes;
        }

        public static Cliente? BuscaPorId(int id)
        {
            var cliente = new Cliente();
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"select * from clientes where id='{id}';";
                var command = new MySqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    cliente.Id = Convert.ToInt32(dataReader["id"]);
                    cliente.Nome = dataReader["nome"].ToString();
                    cliente.Email = dataReader["email"].ToString();
                }
                conn.Close();
            }
            return cliente.Id == 0 ? null : cliente;
        }

        public static void Editar(int id, string nome, string? email)
        {
                using (var conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    var query = $"update clientes set nome = '{nome}',email = '{email}' where id='{id}';";
                    var command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            Console.WriteLine("Cliente Editado Com Suceso!");
            Thread.Sleep(2000);
        }

        public static List<Cliente> ListarClientes()
        {
            var clientes = new List<Cliente>();
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"select * from clientes;";
                var command = new MySqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        Nome = dataReader["nome"].ToString(),
                        Email = dataReader["email"].ToString()

                    });
                }
                conn.Close();
            }
            return clientes;
        }

        public static void ApagarClientePorId(int id)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"delete from clientes where id='{id}'";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            
        }

    }
}
