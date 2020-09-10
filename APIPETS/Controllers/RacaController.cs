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
    public class RacaController : ControllerBase
    {
        RacaRepository rp = new RacaRepository();

        // GET: api/Raca
        [HttpGet]
        public List<Raca> Get()
        {
            return rp.LerTodos();
        }

        // GET: api/Raca/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return rp.BuscarPorId(id);
        }

        // POST: api/Raca
        [HttpPost]
        public Raca Post([FromBody] Raca rc)
        {
            return rp.Cadastrar(rc);
        }

        // PUT: api/Raca/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca rc)
        {
            return rp.Alterar(id, rc);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rp.Excluir(id);
        }
    }
}
