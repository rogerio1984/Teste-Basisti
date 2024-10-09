using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basisti_Client.Data
{
  public class AutorRepository
  {
    public readonly AppDbContext _appDbContext;
    public AutorRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task AddAutorAsync(Autor Autor)
    {
      await _appDbContext.Set<Autor>().AddAsync(Autor); 
      await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Vw_AutorReport>> GetReport()
    {
      return await _appDbContext.Vw_AutorReport.ToListAsync();
    }


    public async Task<List<Autor>> GetAllAutoresAsync()
    {
      return await _appDbContext.Autores.ToListAsync();
    }
    public async Task DeleteAutorAsync(int id)
    {
      var Autor = await _appDbContext.Autores.FindAsync(id);
      if(Autor == null)
      {
        throw new Exception("Autor not found");
      }
      if (Autor != null)
      {        
        _appDbContext.Autores.Remove(Autor);
        await _appDbContext.SaveChangesAsync();
      }
    }
    public async Task<Autor> GetAutorByIdAsync(int id)
    {
      return await  _appDbContext.Autores.FindAsync(id);
    }
    public async Task UpdateAutor(int id, Autor model)
    {
      var Autor = await _appDbContext.Autores.FindAsync(id);
      if(Autor == null)
      {
        throw new Exception("Autor not found");
      }
      if (Autor != null)
      {
        Autor.Nome = model.Nome;

        await _appDbContext.SaveChangesAsync();
      }
    }
  }
}
