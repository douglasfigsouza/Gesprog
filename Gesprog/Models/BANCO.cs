namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANCO")]
    public partial class BANCO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANCO()
        {
            CONTAS_BANCARIAS = new HashSet<CONTAS_BANCARIAS>();
        }

        [Key]
        public int ID_BANCO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME_BANCO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTAS_BANCARIAS> CONTAS_BANCARIAS { get; set; }
    }
}
