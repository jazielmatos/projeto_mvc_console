using Microsoft.AspNetCore.Mvc;

namespace web_app.Controllers
{
    [Route("/clientes")] //rota manual para todos verem '/clientes' , porém ja funciona no automatico 
    public class ClientesController : Controller
    {
        [Route("")] //rota manual para o inicio da rota clientes
        public IActionResult Index()
        {
            return View();
        }
    }
}
