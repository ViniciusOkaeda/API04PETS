using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPETS.Domains;
using APIPETS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPETS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        TipoDePetRepository rp = new TipoDePetRepository();

        // GET: api/TipoDePet
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return rp.LerTodos();
        }

        // GET: api/TipoDePet/5
        [HttpGet("{id}", Name = "Get")]
        public TipoDePet Get(int id)
        {
            return rp.BuscarPorId(id);
        }

        // POST: api/TipoDePet
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet tp)
        {
            return rp.Cadastrar(tp);
        }

        // PUT: api/TipoDePet/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet tp)
        {
            return rp.Alterar(id, tp);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rp.Excluir(id);
        }
    }
}
