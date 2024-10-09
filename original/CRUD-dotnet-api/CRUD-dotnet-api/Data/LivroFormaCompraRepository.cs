using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basisti_Client.Data
{
  public class LivroFormaCompraRepository
  {
    public readonly AppDbContext _appDbContext;
    public LivroFormaCompraRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
 
    public async Task<List<Livro_FormaCompra>> GetAllLivro_FormaCompraByLivroAsync(int codL)
    {
      List<Livro_FormaCompra> lista = await _appDbContext.Livro_FormaCompra.Where(x => x.Codl == codL).ToListAsync();

      foreach (Livro_FormaCompra item in lista)
      {
        item.NomeForma = _appDbContext.FormaCompra.FirstOrDefault(x => x.CodForm == item.CodForm).Descricao;
      }

      return lista;
    }

    public async Task DeleteLivro_FormaCompraByLivroAsync(int codL)
    {
      try
      {
        List<Livro_FormaCompra> Livro_FormaCompra = new List<Livro_FormaCompra>();
        Livro_FormaCompra = await _appDbContext.Livro_FormaCompra.Where(x => x.Codl == codL).ToListAsync();
        foreach (Livro_FormaCompra item in Livro_FormaCompra)
        {
          _appDbContext.Livro_FormaCompra.Remove(item);
          await _appDbContext.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

  }
}
