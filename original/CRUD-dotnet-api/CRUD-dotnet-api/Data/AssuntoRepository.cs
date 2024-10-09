using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basisti_Client.Data
{
  public class AssuntoRepository
  {
    public readonly AppDbContext _appDbContext;
    public AssuntoRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task AddAssuntoAsync(Assunto Assunto)
    {
      await _appDbContext.Set<Assunto>().AddAsync(Assunto); 
      await _appDbContext.SaveChangesAsync();
    }
    public async Task<List<Assunto>> GetAllAssuntosAsync()
    {
      return await _appDbContext.Assuntos.ToListAsync();
    }
    public async Task DeleteAssuntoAsync(int id)
    {
      var Assunto = await _appDbContext.Assuntos.FindAsync(id);
      if(Assunto == null)
      {
        throw new Exception("Assunto not found");
      }
      if (Assunto != null)
      {
        _appDbContext.Assuntos.Remove(Assunto);
        await _appDbContext.SaveChangesAsync();
      }
    }
    public async Task<Assunto> GetAssuntoByIdAsync(int id)
    {
      return await  _appDbContext.Assuntos.FindAsync(id);
    }
    public async Task UpdateAssunto(int id, Assunto model)
    {
      var Assunto = await _appDbContext.Assuntos.FindAsync(id);
      if(Assunto == null)
      {
        throw new Exception("Assunto not found");
      }
      if (Assunto != null)
      {
        Assunto.Descricao = model.Descricao;

        await _appDbContext.SaveChangesAsync();
      }
    }
  }
}
