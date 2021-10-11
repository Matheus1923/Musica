using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrquestraVesp.Models;

namespace InstrumentoVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentoController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public InstrumentoController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Instrumento> Get()
        {
            return Contexto.Instrumentos.ToList();
        }

        [HttpGet("id")]
        public Instrumento Get(int id)
        {
            return Contexto.Instrumentos.First(e => e.IdInstrumento == id);
        }

        [HttpGet("idInstrumento/{idInstrumento}")]
        public List<Instrumento> Filtrar(int id)
        {
            return Contexto.Instrumentos.Where(e => e.IdInstrumento == id).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Instrumento>> Create(Instrumento Instrumento)
        {
            Instrumento.IdInstrumento = 0;
            Contexto.Instrumentos.Add(Instrumento);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Instrumento.IdInstrumento, Instrumento });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Instrumento>> Update(Instrumento Instrumento)
        {
            Contexto.Instrumentos.Update(Instrumento);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Instrumento.IdInstrumento, Instrumento });
        }
    }
}
