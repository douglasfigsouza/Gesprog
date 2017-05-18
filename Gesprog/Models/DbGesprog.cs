namespace Gesprog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbGesprog : DbContext
    {
        public DbGesprog()
            : base("name=DbGesprog")
        {
        }

        public virtual DbSet<BANCO> BANCO { get; set; }
        public virtual DbSet<CIDADE> CIDADE { get; set; }
        public virtual DbSet<CONTAS_BANCARIAS> CONTAS_BANCARIAS { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<HORARIOS> HORARIOS { get; set; }
        public virtual DbSet<NIVEL_DE_CONHECIMENTO> NIVEL_DE_CONHECIMENTO { get; set; }
        public virtual DbSet<PROGRAMADORES> PROGRAMADORES { get; set; }
        public virtual DbSet<TECNOLOGIAS> TECNOLOGIAS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANCO>()
                .Property(e => e.NOME_BANCO)
                .IsUnicode(false);

            modelBuilder.Entity<CIDADE>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CIDADE>()
                .Property(e => e.CAPITAL)
                .IsFixedLength();

            modelBuilder.Entity<CONTAS_BANCARIAS>()
                .Property(e => e.TIPO_CONTA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTAS_BANCARIAS>()
                .Property(e => e.CPF_PROG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONTAS_BANCARIAS>()
                .Property(e => e.AGENCIA_CONTA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTAS_BANCARIAS>()
                .Property(e => e.NUM_CONTA)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.SIGLA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .HasMany(e => e.CIDADE)
                .WithOptional(e => e.ESTADO)
                .HasForeignKey(e => e.ESTADOID);

            modelBuilder.Entity<ESTADO>()
                .HasMany(e => e.CIDADE1)
                .WithOptional(e => e.ESTADO1)
                .HasForeignKey(e => e.ESTADOID);

            modelBuilder.Entity<HORARIOS>()
                .Property(e => e.DESC_HR)
                .IsUnicode(false);

            modelBuilder.Entity<HORARIOS>()
                .HasMany(e => e.PROGRAMADORES)
                .WithMany(e => e.HORARIOS)
                .Map(m => m.ToTable("MELHORES_HORARIOS_TRAB").MapLeftKey("ID_HR").MapRightKey("ID_PROG"));

            modelBuilder.Entity<NIVEL_DE_CONHECIMENTO>()
                .Property(e => e.OUTROS)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.NOME_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.FONE_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.SKYPE_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.LINKEDIN_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.EMAIL_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.PORTIFOLIO_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.DISPHRTRDIA_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.PRETSAL_PROG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROGRAMADORES>()
                .Property(e => e.LINKCRUD_PROG)
                .IsUnicode(false);

            modelBuilder.Entity<PROGRAMADORES>()
                .HasMany(e => e.NIVEL_DE_CONHECIMENTO)
                .WithRequired(e => e.PROGRAMADORES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TECNOLOGIAS>()
                .Property(e => e.DESC_TECNO)
                .IsUnicode(false);

            modelBuilder.Entity<TECNOLOGIAS>()
                .HasMany(e => e.NIVEL_DE_CONHECIMENTO)
                .WithRequired(e => e.TECNOLOGIAS)
                .WillCascadeOnDelete(false);
        }
    }
}
