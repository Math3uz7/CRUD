using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Context;
using CRUD.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AppController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(FirstEntities contato)
        {
            _context.Add(contato);
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var contato = _context.Contatos.Find(Id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }


        [HttpGet("Get by name")]
        public IActionResult GetbyName(string nome)
        {
            var contato = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contato);

        }


        [HttpPut("{Id}")]
        public IActionResult Update(int Id, FirstEntities contato)
        {
            var contatoBase = _context.Contatos.Find(Id);

            if (contatoBase == null)
            {
                return NotFound();
            }

            contatoBase.Nome = contato.Nome;
            contatoBase.Sobrenome = contato.Sobrenome;
            contatoBase.Idade = contato.Idade;
            contatoBase.Numero = contato.Numero;
            contatoBase.Ativo = contato.Ativo;

            _context.Contatos.Update(contato);
            _context.SaveChanges();

            return Ok(contato);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var contato = _context.Contatos.Find(Id);
            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }




    }
}