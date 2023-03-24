using Microsoft.EntityFrameworkCore;

public class AplicacaoDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options) { }

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