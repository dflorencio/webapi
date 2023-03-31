using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class AplicacaoDBContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public AplicacaoDBContext(DbContextOptions<AplicacaoDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .Property(p => p.Descricao).HasMaxLength(500).IsRequired(false);
            builder.Entity<Produto>()
           .Property(p => p.Nome).HasMaxLength(maxLength: 120).IsRequired();
            builder.Entity<Produto>()
           .Property(p => p.Codigo).HasMaxLength(maxLength: 20).IsRequired();

        }

    }
}