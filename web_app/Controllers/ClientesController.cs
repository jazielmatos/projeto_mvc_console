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
            if(string.IsNullOrEmpty(cliente.Nome))
            {
                ViewBag.erro = "O nome não pode ser nulo!";
                return View();
            }

            cliente.Salvar();
          return Redirect("/clientes");
        }

        [Route("clientes/{id}/apagar")]
        public IActionResult Apagar([FromRoute] int id)
        {
          Cliente.ApagarClientePorId(id);
          return Redirect("/clientes");
        }
    }
}
