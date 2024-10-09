using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
namespace Basisti_Client.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }
    public DbSet<Livro_Assunto> Livro_Assuntos { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro_Autor> Livro_Autores { get; set; }
    public DbSet<Livro_FormaCompra> Livro_FormaCompra { get; set; }
    public DbSet<FormaCompra> FormaCompra { get; set; }
    public DbSet<Vw_AutorReport> Vw_AutorReport { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Livro_Assunto>()
          .HasKey(bs => new { bs.Codl, bs.CodAs });
      modelBuilder.Entity<Livro_Autor>()
         .HasKey(bs => new { bs.Codl, bs.CodAu });
      modelBuilder.Entity<Livro_FormaCompra>()
        .HasKey(bs => new { bs.CodForm, bs.Codl });

      modelBuilder.Entity<Vw_AutorReport>(eb =>
      {
        eb.HasNoKey();
        eb.ToView("vw_autores");
      });
    }

  }
}
