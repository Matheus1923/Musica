using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrquestraVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrquestraVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrquestraController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public OrquestraController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }
            
        [HttpGet]
        public List<Orquestra> Get()
        {
            return Contexto.Orquestras.ToList();
        }

        [HttpGet("id")]
        public Orquestra Get(int id)
        {
            return Contexto.Orquestras.First(e => e.IdOrquestra == id);
        }

        [HttpGet("idorquestra/{idorquestra}")]
        public List<Orquestra> Filtrar(int id)
        {
            return Contexto.Orquestras.Where(e => e.IdOrquestra == id).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Orquestra>> Create(Orquestra Orquestra)
        {
            Orquestra.IdOrquestra = 0;
            Contexto.Orquestras.Add(Orquestra);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Orquestra.IdOrquestra, Orquestra });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Orquestra>> Update(Orquestra Orquestra)
        {
            Contexto.Orquestras.Update(Orquestra);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Orquestra.IdOrquestra, Orquestra });
        }
    }
}
