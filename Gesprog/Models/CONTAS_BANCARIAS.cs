namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTAS_BANCARIAS
    {
        [Key]
        public int ID_CONTA { get; set; }

        public int? ID_BANCO { get; set; }

        public int? ID_PROG { get; set; }

        [Required]
        [StringLength(15)]
        public string TIPO_CONTA { get; set; }

        [StringLength(9)]
        public string CPF_PROG { get; set; }

        [Required]
        [StringLength(10)]
        public string AGENCIA_CONTA { get; set; }

        [Required]
        [StringLength(10)]
        public string NUM_CONTA { get; set; }

        public virtual BANCO BANCO { get; set; }

        public virtual PROGRAMADORES PROGRAMADORES { get; set; }
    }
}
