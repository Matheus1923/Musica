using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrquestraVesp.Models
{
    [Table("Instrumento")]
    public class Instrumento
    {
        [Key]
        [Column("idinstrumento")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdInstrumento { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = " O campo deve conter entre 10 á 50 caracteres")]
        [Column("nome")]

        public string Nome { get; set; }

        [Column("idorquestra")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public int IdOrquestra { get; set; }
    }
}
