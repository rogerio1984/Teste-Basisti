using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basisti_Client.Data
{
  public class LivroAutorRepository
  {
    public readonly AppDbContext _appDbContext;
    public LivroAutorRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task AddLivroAutorAsync(Livro_Autor Livro_Autor)
    {
      await _appDbContext.Set<Livro_Autor>().AddAsync(Livro_Autor); 
      await _appDbContext.SaveChangesAsync();
    }
    public async Task<List<Livro_Autor>> GetAllLivro_AutorsByLivroAsync(int idLivro)
    {
      return await _appDbContext.Livro_Autores.Where(x => x.Codl == idLivro).ToListAsync();
    }
    public async Task DeleteLivro_AutorByLivroAsync(int idLivro)
    {
      List<Livro_Autor> Livro_autor = new List<Livro_Autor>();
      Livro_autor = await _appDbContext.Livro_Autores.Where(x=>x.Codl == idLivro).ToListAsync();

      foreach (Livro_Autor item in Livro_autor)
      {
        _appDbContext.Livro_Autores.Remove(item);
        await _appDbContext.SaveChangesAsync();
      }
    }

    public async Task DeleteLivro_AutorByAutorAsync(int codAu)
    {
      var Livro_Autor = await _appDbContext.Livro_Autores.Where(x => x.CodAu == codAu).ToListAsync();

      foreach (Livro_Autor item in Livro_Autor)
      {
        _appDbContext.Livro_Autores.Remove(item);
        await _appDbContext.SaveChangesAsync();
      }
    }

  }
}
