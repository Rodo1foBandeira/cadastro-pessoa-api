using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cadastro_pessoa_api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cadastro_pessoa_api.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly PBD_Prj03Context _context;
        
        public CidadeController()
        {
            _context = new PBD_Prj03Context();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cidade>> Get()
        {
            var cidades = _context.Cidade.Include(x => x.Uf).ToList();
            cidades.ForEach(x => x.Uf.Cidades = null);
            return cidades;
        }

        [HttpGet("{id}")]
        public ActionResult<Cidade> GetById(int id)
        {
            var cidade = _context.Cidade.First(x => x.Id == id);
            //cidade.Uf.Cidades = null;
            return cidade;
        }

        [HttpPost]
        public ActionResult<Cidade> Post(Cidade request)
        {
            _context.Cidade.Add(request);
            _context.SaveChanges();
            return request;
        }

        [HttpPut]
        public ActionResult<Cidade> Put(Cidade request)
        {
            _context.Cidade.Update(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove(new Cidade { Id = id });
            _context.SaveChanges();
        }
    }
}