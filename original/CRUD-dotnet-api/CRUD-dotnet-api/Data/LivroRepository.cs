using Basisti_Client.Model;
using Microsoft.EntityFrameworkCore;

namespace Basisti_Client.Data
{
  public class LivroRepository
  {
    public readonly AppDbContext _appDbContext;
    private readonly LivroAssuntoRepository _livroAssuntoRepository;
    private readonly LivroAutorRepository _livroAutorRepository;
    private readonly LivroFormaCompraRepository _livroFormaCompraRepository;
    public LivroRepository(AppDbContext appDbContext, LivroAssuntoRepository livroAssuntoRepository, LivroAutorRepository livroAutorRepository, LivroFormaCompraRepository livroFormaCompraRepository)
    {
      _appDbContext = appDbContext;
      _livroAssuntoRepository = livroAssuntoRepository;
      _livroAutorRepository = livroAutorRepository;
      _livroFormaCompraRepository = livroFormaCompraRepository;

    }
    public async Task AddLivroAsync(Livro livro)
    {
      try
      {
        await _appDbContext.Set<Livro>().AddAsync(livro);
        await _appDbContext.SaveChangesAsync();

        Livro_Assunto livro_Assunto = new Livro_Assunto() { Codl = livro.Codl, CodAs = Convert.ToInt32(livro.AssuntosStr) };

        await _livroAssuntoRepository.AddLivroAssuntoAsync(livro_Assunto);

        Livro_Autor livro_autor = new Livro_Autor() { Codl = livro.Codl, CodAu = Convert.ToInt32(livro.AutoresStr) };

        await _livroAutorRepository.AddLivroAutorAsync(livro_autor);

      }
      catch (Exception ex)
      {

        throw;
      }

    }
    public async Task<List<Livro>> GetAllLivrosAsync()
    {
      List<Livro> retorno = await _appDbContext.Livros.ToListAsync();

      foreach (Livro item in retorno)
      {
        List<int> assuntos = _appDbContext.Livro_Assuntos.Where(x => x.Codl == item.Codl).Select(x => x.CodAs).ToList();
        List<Livro_FormaCompra> listaValores = new List<Livro_FormaCompra>();


        foreach (int codas in assuntos)
        {
          item.Assuntos.Add(_appDbContext.Assuntos.FirstOrDefault(x => x.CodAs == codas));
        }
        item.AssuntosStr = String.Join(',', item.Assuntos.Select(x => x.Descricao));


        List<int> autores = _appDbContext.Livro_Autores.Where(x => x.Codl == item.Codl).Select(x => x.CodAu).ToList();

        foreach (int codau in autores)
        {
          item.Autores.Add(_appDbContext.Autores.FirstOrDefault(x => x.CodAu == codau));
        }
        item.AutoresStr = String.Join(',', item.Autores.Select(x => x.Nome));


        try
        {
          item.Livro_FormaCompra = _appDbContext.Livro_FormaCompra.Where(x => x.Codl == item.Codl).ToList();

          foreach (Livro_FormaCompra valores in item.Livro_FormaCompra)
          {
            valores.NomeForma = _appDbContext.FormaCompra.FirstOrDefault(x => x.CodForm == valores.CodForm).Descricao;
          }

          item.ValoresStr = String.Join(',', item.Livro_FormaCompra.Select(x => string.Concat(x.NomeForma, ": R$ ", x.Valor.ToString())));

        }
        catch (Exception ex)
        {

          throw;
        }
       
      }

      return retorno;
    }
    public async Task DeleteLivroAsync(int id)
    {
      var Livro = await _appDbContext.Livros.FindAsync(id);
      if (Livro == null)
      {
        throw new Exception("Livro not found");
      }
      if (Livro != null)
      {
        await _livroAssuntoRepository.DeleteLivro_AssuntoByLivroAsync(id);
        await _livroAutorRepository.DeleteLivro_AutorByLivroAsync(id);
        await _livroFormaCompraRepository.DeleteLivro_FormaCompraByLivroAsync(id);

        _appDbContext.Livros.Remove(Livro);
        await _appDbContext.SaveChangesAsync();
      }
    }
    public async Task<Livro> GetLivroByIdAsync(int id)
    {

      var item = await _appDbContext.Livros.FindAsync(id);
      List<int> assuntos = _appDbContext.Livro_Assuntos.Where(x => x.Codl == item.Codl).Select(x => x.CodAs).ToList();


      foreach (int codas in assuntos)
      {
        item.AssuntosStr = codas.ToString();
        item.Assuntos.Add(_appDbContext.Assuntos.FirstOrDefault(x => x.CodAs == codas));
      }

      List<int> autores = _appDbContext.Livro_Autores.Where(x => x.Codl == item.Codl).Select(x => x.CodAu).ToList();

      foreach (int codau in autores)
      {
        item.AutoresStr = codau.ToString();
        item.Autores.Add(_appDbContext.Autores.FirstOrDefault(x => x.CodAu == codau));
      }
      return item;
    }
    public async Task UpdateLivro(int id, Livro model)
    {
      var Livro = await _appDbContext.Livros.FindAsync(id);
      if (Livro == null)
      {
        throw new Exception("Livro not found");
      }
      if (Livro != null)
      {
        Livro.Titulo = model.Titulo;
        Livro.Editora = model.Editora;
        Livro.Edicao = model.Edicao;
        Livro.AnoPublicacao = model.AnoPublicacao;
        await _appDbContext.SaveChangesAsync();

        await _livroAssuntoRepository.DeleteLivro_AssuntoByLivroAsync(id);

        Livro_Assunto livro_Assunto = new Livro_Assunto() { Codl = id, CodAs = Convert.ToInt32(model.AssuntosStr) };

        await _livroAssuntoRepository.AddLivroAssuntoAsync(livro_Assunto);

        await _livroAutorRepository.DeleteLivro_AutorByLivroAsync(id);

        Livro_Autor livro_autor = new Livro_Autor() { Codl = id, CodAu = Convert.ToInt32(model.AutoresStr) };

        await _livroAutorRepository.AddLivroAutorAsync(livro_autor);

      }
    }
  }
}
