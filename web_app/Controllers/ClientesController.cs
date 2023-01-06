using Microsoft.AspNetCore.Mvc;
using negocio.Models;

namespace web_app.Controllers
{
    //[Route("/clientes")] //rota manual para todos verem '/clientes' , porém ja funciona no automatico 
    public class ClientesController : Controller
    {
        //[Route("")] //rota manual para o inicio da rota clientes
        public IActionResult Index()
        {
            ViewBag.clientes = Cliente.ListarClientes();
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }
        public IActionResult Cadastrar([FromForm] Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                ViewBag.erro = "O nome não pode ser nulo!";
                return View();
            }
            else
            {
                cliente.Salvar();
                return Redirect("/clientes");
            }
        }

        [Route("clientes/{id}/atualizar")]
        public IActionResult Atualizar([FromRoute] int id,[FromForm] Cliente cliente)
        {
            
            Cliente clienteEd = cliente;
            clienteEd.Id = id;
            if (string.IsNullOrEmpty(clienteEd.Nome))
            {
                ViewBag.erro = "O nome não pode ser nulo!";
                return View();
            }
            else
            {
                Cliente.Editar(clienteEd.Id, clienteEd.Nome, clienteEd.Email);
                return Redirect("/clientes");
            }
        }



    [Route("clientes/{id}/apagar")]
        public IActionResult Apagar([FromRoute] int id)
        {
          Cliente.ApagarClientePorId(id);
          return Redirect("/clientes");
        }
        
        [Route("clientes/{id}/editar")]
        public IActionResult Editar([FromRoute] int id)
        {
          Cliente? cliente= Cliente.BuscaPorId(id);
            if (cliente == null)
            {
                ViewBag.erro = "Cliente não existe";
                return Redirect("/clientes/Atualizar");
            }
          ViewBag.cliente = cliente;
          return View();
        }
    }
}
