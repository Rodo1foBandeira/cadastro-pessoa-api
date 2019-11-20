using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cadastro_pessoa_api.Models;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Controllers
{
    [Route("api/uf")]
    [ApiController]
    public class UfController : ControllerBase
    {
        private readonly PBD_Prj03Context _context;
        
        public UfController()
        {
            _context = new PBD_Prj03Context();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Uf>> Get()
        {
            return _context.Uf.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Uf> GetById(int id)
        {
            return _context.Uf.First(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<Uf> Post(Uf request)
        {
            _context.Uf.Add(request);
            _context.SaveChanges();
            return request;
        }

        [HttpPut]
        public ActionResult<Uf> Put(Uf request)
        {
            _context.Uf.Update(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove(new Uf { Id = id });
            _context.SaveChanges();
        }
    }
}