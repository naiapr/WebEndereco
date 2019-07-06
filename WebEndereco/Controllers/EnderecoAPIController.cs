using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEndereco.Models;

namespace WebEndereco.Controllers
{
   
    public class EnderecoAPIController : ControllerBase
    {
        private readonly Context _context;

        public EnderecoAPIController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return _context.Enderecos.ToList();
        }

        [HttpGet("{id}", Name = "enderecoCriado")]
        public IActionResult GetById(int id)
        {
            var cat = _context.Enderecos.FirstOrDefault(x => x.EnderecoID == id);
            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco cat)
        {
            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(cat);
                _context.SaveChanges();
                return new CreatedAtRouteResult("enderecoCriado", new { id = cat.Id }, cat);
            }

            return BadRequest(ModelState);

        }
    }
}