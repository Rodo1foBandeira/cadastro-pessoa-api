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
            return _context.Pessoa.Include(x => x.Bairro).Include(x => x.Cidade).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetById(int id)
        {
            return _context.Pessoa.Include(x => x.Fones).Include(x => x.Emails).First(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post(Pessoa request)
        {
            foreach (var item in request.Fones)
            {
                item.PessoaId = request.Id;
                _context.Fone.Add(item);
            }
            request.Fones = null;
            foreach (var item in request.Emails)
            {
                item.PessoaId = request.Id;
                _context.Email.Add(item);
            }
            request.Emails = null;
            _context.Pessoa.Add(request);
            _context.SaveChanges();
            return request;
        }
/*/
        private void GenericUpdate<E, R>(R request){
            var excluidos = _context.Set<E>()
                .Where(x => 
                    !request.Where(y => y.Id.HasValue).Select(y => y.Id).Contains(x.Id)
                );
            foreach (var item in excluidos)
            {
                _context.Remove(item);
            }
            foreach (var item in request)
            {
                if (item.Id.HasValue){
                    _context.Set<E>().Update(item);
                } else {
                    item.PessoaId = request.Id;
                    _context.Set<E>().Add(item);
                }                
            }
        }
*/
        [HttpPut]
        public ActionResult<Pessoa> Put(Pessoa request)
        {
            var fonesExcluidos = _context.Fone
                .Where(x =>
                    x.PessoaId == request.Id &&
                    !request.Fones.Where(y => y.Id.HasValue).Select(y => y.Id).Contains(x.Id)
                );
            foreach (var item in fonesExcluidos)
            {
                _context.Remove(item);
            }
            foreach (var item in request.Fones)
            {
                if (item.Id.HasValue){
                    _context.Fone.Update(item);
                } else {
                    item.PessoaId = request.Id;
                    _context.Fone.Add(item);
                }                
            }
            request.Fones = null;
            //
            var emailsExcluidos = _context.Email
                .Where(x =>
                    x.PessoaId == request.Id &&
                    !request.Emails.Where(y => y.Id.HasValue).Select(y => y.Id).Contains(x.Id)
                );
            foreach (var item in emailsExcluidos)
            {
                _context.Remove(item);
            }
            foreach (var item in request.Emails)
            {
                if (item.Id.HasValue){
                    _context.Email.Update(item);
                } else {
                    item.PessoaId = request.Id;
                    _context.Email.Add(item);
                }                
            }
            request.Emails = null;
            _context.Pessoa.Update(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var fones = _context.Fone.Where(x => x.PessoaId == id).ToList();
            foreach (var fone in fones)
            {
                _context.Remove(fone);
            }

            var emails = _context.Email.Where(x => x.PessoaId == id).ToList();
            foreach (var email in emails)
            {
                _context.Remove(email);
            }
            
            _context.SaveChanges();

            _context.Remove(new Pessoa { Id = id });
            _context.SaveChanges();
        }
    }
}