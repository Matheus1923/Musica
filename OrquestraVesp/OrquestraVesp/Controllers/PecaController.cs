using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrquestraVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PecaVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecaController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public PecaController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Peca> Get()
        {
            return Contexto.Pecas.ToList();
        }

        [HttpGet("id")]
        public Peca Get(int id)
        {
            return Contexto.Pecas.First(e => e.IdPeca == id);
        }

        [HttpGet("idPeca/{idPeca}")]
        public List<Peca> Filtrar(int id)
        {
            return Contexto.Pecas.Where(e => e.IdPeca == id).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Peca>> Create(Peca Peca)
        {
            Peca.IdPeca = 0;
            Contexto.Pecas.Add(Peca);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Peca.IdPeca, Peca });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Peca>> Update(Peca Peca)
        {
            Contexto.Pecas.Update(Peca);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Peca.IdPeca, Peca });
        }
    }
}
