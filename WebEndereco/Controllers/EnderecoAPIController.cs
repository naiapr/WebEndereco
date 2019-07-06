using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebEndereco.Models;


namespace WebEndereco.Controllers
{


    public class EnderecoAPIController : Controller
    {

        private readonly Context _context;

        public EnderecoAPIController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Enderecos.ToList());
        }

        public IActionResult BuscaCep()
        {
            var cep = HttpContext.Request.Query["cep"].ToString();
            WebClient client = new WebClient();
            string json = client.DownloadString("http://viacep.com.br/ws/" + cep + "/json/");
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(json);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}