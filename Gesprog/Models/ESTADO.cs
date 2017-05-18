namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTADO")]
    public partial class ESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO()
        {
            CIDADE = new HashSet<CIDADE>();
            CIDADE1 = new HashSet<CIDADE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ESTADOID { get; set; }

        [Required]
        [StringLength(2)]
        public string SIGLA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIDADE> CIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIDADE> CIDADE1 { get; set; }
    }
}
