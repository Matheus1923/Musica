using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrquestraVesp.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [Column("idmarca")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public Int32 IdMarca { get; set; }

        [Column("nome")]
        [Required (AllowEmptyStrings = false, ErrorMessage ="O campo não deve ser nulo")]

        public string Nome { get; set; }

        [Column("idinstrumento")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public int IdInstrumento { get; set; }
        
    }
}
