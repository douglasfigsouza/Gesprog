namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TECNOLOGIAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TECNOLOGIAS()
        {
            NIVEL_DE_CONHECIMENTO = new HashSet<NIVEL_DE_CONHECIMENTO>();
        }

        [Key]
        public int ID_TECNO { get; set; }

        [StringLength(50)]
        public string DESC_TECNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NIVEL_DE_CONHECIMENTO> NIVEL_DE_CONHECIMENTO { get; set; }
    }
}
