using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cadastro_pessoa_api.Models;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PBD_Prj03Context _context;
        
        public PessoaController()
        {
            _context = new PBD_Prj03Context();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            return _context.Pessoa.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetById(int id)
        {
            return _context.Pessoa.First(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post(Pessoa request)
        {
            _context.Pessoa.Add(request);
            _context.SaveChanges();
            return request;
        }

        [HttpPut]
        public ActionResult<Pessoa> Put(Pessoa request)
        {
            _context.Pessoa.Update(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete]
        public void Delete(Pessoa request)
        {
            _context.Remove(request);
            _context.SaveChanges();
        }
    }
}