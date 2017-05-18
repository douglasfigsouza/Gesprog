namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CIDADE")]
    public partial class CIDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIDADE()
        {
            PROGRAMADORES = new HashSet<PROGRAMADORES>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CIDADEID { get; set; }

        public int? ESTADOID { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME { get; set; }

        [MaxLength(2)]
        public byte[] CAPITAL { get; set; }

        public virtual ESTADO ESTADO { get; set; }

        public virtual ESTADO ESTADO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROGRAMADORES> PROGRAMADORES { get; set; }
    }
}
