using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrquestraVesp.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Orquestra> Orquestras { get; set; }

        public DbSet<Instrumento> Instrumentos { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Peca> Pecas { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
