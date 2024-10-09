using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basisti_Client.Data
{
  public class LivroAssuntoRepository
  {
    public readonly AppDbContext _appDbContext;
    public LivroAssuntoRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task AddLivroAssuntoAsync(Livro_Assunto Livro_Assunto)
    {  
        await _appDbContext.Set<Livro_Assunto>().AddAsync(Livro_Assunto);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteLivro_AssuntoByLivroAsync(int codL)
    {
      try
      {
        List<Livro_Assunto> Livro_Assunto = new List<Livro_Assunto>();
        Livro_Assunto = await _appDbContext.Livro_Assuntos.Where(x => x.Codl == codL).ToListAsync();
        foreach (Livro_Assunto item in Livro_Assunto)
        {
          _appDbContext.Livro_Assuntos.Remove(item);
          await _appDbContext.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }
    public async Task DeleteLivro_AssuntoByAssuntoAsync(int codAs)
    {
      var Livro_Assunto = await _appDbContext.Livro_Assuntos.Where(x => x.CodAs == codAs).ToListAsync();

      foreach (Livro_Assunto item in Livro_Assunto)
      {
        _appDbContext.Livro_Assuntos.Remove(item);
        await _appDbContext.SaveChangesAsync();
      }
    }

  }
}
