namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NIVEL_DE_CONHECIMENTO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_TECNO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PROG { get; set; }

        public int NIVEL { get; set; }

        [StringLength(400)]
        public string OUTROS { get; set; }

        [NotMapped]
        public string DESC_TECNO { get; set; }
        [NotMapped]
        public IList<NIVEL_DE_CONHECIMENTO> ListaDeNiveisDeConhecimento { get; set;}
        [NotMapped]
        public bool Checked { get; set; }
        public virtual TECNOLOGIAS TECNOLOGIAS { get; set; }

        public virtual PROGRAMADORES PROGRAMADORES { get; set; }
    }
}
