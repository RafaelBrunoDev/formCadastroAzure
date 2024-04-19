using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace formCadastroAzure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context1")
        {
        }

        public virtual DbSet<tbl_Cadastro> tbl_Cadastro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Cadastro>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cadastro>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cadastro>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cadastro>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cadastro>()
                .Property(e => e.Cidade)
                .IsUnicode(false);
        }
    }
}
