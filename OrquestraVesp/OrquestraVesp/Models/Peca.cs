using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrquestraVesp.Models
{
    [Table("Peca")]
    public class Peca
    {
        [Key]
        [Column("idpeca")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public Int32 IdPeca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é obrigatório")]
        [Column("nome")]

        public string Nome { get; set; }

        [Column("idinstrumento")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public int IdInstrumento { get; set; }

    }
}
