namespace Gesprog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROGRAMADORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROGRAMADORES()
        {
            CONTAS_BANCARIAS = new HashSet<CONTAS_BANCARIAS>();
            NIVEL_DE_CONHECIMENTO = new HashSet<NIVEL_DE_CONHECIMENTO>();
            HORARIOS = new HashSet<HORARIOS>();
        }

        [Key]
        public int ID_PROG { get; set; }

        public int? CIDADEID { get; set; }

        [Required(ErrorMessage ="O campo Nome é obrigatório!")]
        [Display(Name = "Nome")]
        [StringLength(200)]
        public string NOME_PROG { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [Display(Name = "Telefone")]
        [StringLength(15)]
        public string FONE_PROG { get; set; }

        [Required(ErrorMessage = "O campo Skype é obrigatório!")]
        [Display(Name = "Skype")]
        [StringLength(200)]
        public string SKYPE_PROG { get; set; }

        [Required(ErrorMessage = "O campo Linkedin é obrigatório!")]
        [Display(Name = "Linkedin")]
        [StringLength(200)]
        public string LINKEDIN_PROG { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [Display(Name = "Email")]
        [StringLength(200)]
        public string EMAIL_PROG { get; set; }

        [Display(Name = "Portifólio")]
        [StringLength(8000)]
        public string PORTIFOLIO_PROG { get; set; }

        [Required]
        [StringLength(50)]
        public string DISPHRTRDIA_PROG { get; set; }

        [Display(Name = "Pretenção Salarial / Hr")]
        public decimal PRETSAL_PROG { get; set; }

        [StringLength(200)]
        public string LINKCRUD_PROG { get; set; }

        public virtual CIDADE CIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTAS_BANCARIAS> CONTAS_BANCARIAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NIVEL_DE_CONHECIMENTO> NIVEL_DE_CONHECIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HORARIOS> HORARIOS { get; set; }
    }
}
