using Basisti_Client.Data;
using Basisti_Client.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Basisti_Client.Controllers
{
  /// <summary>
  /// Controller responsável por manipular dados de livros
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class LivroController : ControllerBase
  {
    private readonly LivroRepository _livroRepository;
    private readonly LivroAssuntoRepository _livroAssuntoRepository;
    private readonly LivroAutorRepository _livroAutorRepository;
    public LivroController(LivroRepository livroRepository, LivroAssuntoRepository livroAssuntoRepository, LivroAutorRepository livroAutorRepository)
    {
      _livroRepository = livroRepository;
      _livroAssuntoRepository = livroAssuntoRepository;
      _livroAutorRepository = livroAutorRepository;

    }

    /// <summary>
    /// Método responsável por incluir novo livro
    /// </summary>
    /// <param name="model">Livro</param>
    /// <returns>StatusCode</returns>
    [HttpPost]
    public async Task<ActionResult> AddLivro([FromBody] Livro model)
    {
      await _livroRepository.AddLivroAsync(model);
      return Ok();
    }
    /// <summary>
    /// Método responsável por retornar livros cadastrados
    /// </summary>
    /// <returns>List<Livro></returns>
    [HttpGet]
    public async Task<ActionResult> GetAllLivros()
    {
      var Livros = await _livroRepository.GetAllLivrosAsync();

      return Ok(Livros);
    }
    /// <summary>
    /// Método responsável por retornar um único livro pelo seu código
    /// </summary>
    /// <param name="id">Código do livro</param>
    /// <returns>Livro</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetLivroById([FromRoute] int id)
    {
      var Livro = await _livroRepository.GetLivroByIdAsync(id);
      
      return Ok(Livro);
    }
    /// <summary>
    /// Método responsável por excluir um livro
    /// </summary>
    /// <param name="id">Código do livro</param>
    /// <returns>StatusCode</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLivro([FromRoute] int id)
    {
      await _livroRepository.DeleteLivroAsync(id);
      return Ok();
    }
    /// <summary>
    /// Método responsável por atualizar um registro de livro.
    /// </summary>
    /// <param name="id">Código do livro</param>
    /// <param name="model">Livro</param>
    /// <returns>StatusCode</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLivro([FromRoute] int id, [FromBody] Livro model)
    {
      await _livroRepository.UpdateLivro(id, model);
      return Ok();
    }

  }
}
