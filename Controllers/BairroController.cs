using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cadastro_pessoa_api.Models;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Controllers
{
    [Route("api/bairro")]
    [ApiController]
    public class BairroController : ControllerBase
    {
        private readonly PBD_Prj03Context _context;
        
        public BairroController()
        {
            _context = new PBD_Prj03Context();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bairro>> Get()
        {
            return _context.Bairro.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Bairro> GetById(int id)
        {
            return _context.Bairro.First(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<Bairro> Post(Bairro request)
        {
            _context.Bairro.Add(request);
            _context.SaveChanges();
            return request;
        }

        [HttpPut]
        public ActionResult<Bairro> Put(Bairro request)
        {
            _context.Bairro.Update(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete]
        public void Delete(Bairro request)
        {
            _context.Remove(request);
            _context.SaveChanges();
        }
    }
}