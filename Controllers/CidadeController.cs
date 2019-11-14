using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cadastro_pessoa_api.Models;
using System.Collections.Generic;

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
            return _context.Cidade.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Cidade> GetById(int id)
        {
            return _context.Cidade.First(x => x.Id == id);
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

        [HttpDelete]
        public void Delete(Cidade request)
        {
            _context.Remove(request);
            _context.SaveChanges();
        }
    }
}