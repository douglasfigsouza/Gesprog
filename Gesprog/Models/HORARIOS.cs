namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HORARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HORARIOS()
        {
            PROGRAMADORES = new HashSet<PROGRAMADORES>();
        }

        [Key]
        public int ID_HR { get; set; }

        [Required]
        [StringLength(200)]
        public string DESC_HR { get; set; }
        [NotMapped]
        public IList<HORARIOS> ListaDeHorarios;
        [NotMapped]
        public bool Checked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROGRAMADORES> PROGRAMADORES { get; set; }
    }
}
