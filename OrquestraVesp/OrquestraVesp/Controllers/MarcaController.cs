using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrquestraVesp.Models;

namespace MarcaVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public MarcaController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Marca> Get()
        {
            return Contexto.Marcas.ToList();
        }

        [HttpGet("id")]
        public Marca Get(int id)
        {
            return Contexto.Marcas.First(e => e.IdMarca == id);
        }

        [HttpGet("idMarca/{idMarca}")]
        public List<Marca> Filtrar(int id)
        {
            return Contexto.Marcas.Where(e => e.IdMarca == id).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Marca>> Create(Marca Marca)
        {
            Marca.IdMarca = 0;
            Contexto.Marcas.Add(Marca);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.IdMarca, Marca });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Marca>> Update(Marca Marca)
        {
            Contexto.Marcas.Update(Marca);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.IdMarca, Marca });
        }
    }
}
