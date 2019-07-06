using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebEndereco.Models;

namespace WebEndereco.Controllers
{
    public class EnderecoController : Controller
    {

        private readonly Context _context;

        public EnderecoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ConsultarEndereco()
        {


            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/01001000/json/");
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(json);

            return RedirectToAction("Index");
        }


        public IActionResult btnCadastrar(Endereco endereco)

        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

         
        public IActionResult List()

        {
            _context.Enderecos.ToList();
            return List();

        }

    }
}