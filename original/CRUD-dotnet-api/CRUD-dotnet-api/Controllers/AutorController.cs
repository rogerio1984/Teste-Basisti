using Basisti_Client.Data;
using Basisti_Client.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Basisti_Client.Controllers
{
  /// <summary>
  /// Controller responsável por manipular dados de autores
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class autorController : ControllerBase
  {
    private readonly AutorRepository _autorRepository;
    private readonly LivroAutorRepository _livroAutorRepository;
    public autorController(AutorRepository autorRepository, LivroAutorRepository livroAutorRepository)
    {
      _autorRepository = autorRepository;
      _livroAutorRepository = livroAutorRepository;

    }

    /// <summary>
    /// Método responsável por incluir novo autor
    /// </summary>
    /// <param name="model">autor</param>
    /// <returns>StatusCode</returns>
    [HttpPost]
    public async Task<ActionResult> AddAutor([FromBody] Autor model)
    {
      await _autorRepository.AddAutorAsync(model);
      return Ok();
    }

    /// <summary>
    /// Método responsável por retornar autores cadastrados
    /// </summary>
    /// <returns>List<Autor></returns>
    [HttpGet("GetReport")]
    public async Task<ActionResult> GetReport()
    {
      var autores = await _autorRepository.GetReport();     

      return Ok(autores);
    }


    /// <summary>
    /// Método responsável por retornar autores cadastrados
    /// </summary>
    /// <returns>List<Autor></returns>
    [HttpGet]
    public async Task<ActionResult> GetAllAutores()
    {
      var autores = await _autorRepository.GetAllAutoresAsync();
      foreach (Autor item in autores)
      {
        item.Livro_Autores = _livroAutorRepository.GetAllLivro_AutorsByLivroAsync(item.CodAu).Result; 
      }

      return Ok(autores);
    }
    /// <summary>
    /// Método responsável por retornar um único autor pelo seu código
    /// </summary>
    /// <param name="id">Código do autor</param>
    /// <returns>Autor</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAutorById([FromRoute] int id)
    {
      var autor = await _autorRepository.GetAutorByIdAsync(id);
      autor.Livro_Autores = _livroAutorRepository.GetAllLivro_AutorsByLivroAsync(id).Result;
      return Ok(autor);
    }
    /// <summary>
    /// Método responsável por excluir um autor
    /// </summary>
    /// <param name="codAu">Código do autor</param>
    /// <returns>StatusCode</returns>
    [HttpDelete("{codAu}")]
    public async Task<ActionResult> DeleteAutor([FromRoute] int codAu)
    {
      await _livroAutorRepository.DeleteLivro_AutorByAutorAsync(codAu);
      await _autorRepository.DeleteAutorAsync(codAu);
      return Ok();
    }
    /// <summary>
    /// Método responsável por atualizar um registro de autor.
    /// </summary>
    /// <param name="id">Código do autor</param>
    /// <param name="model">autor</param>
    /// <returns>StatusCode</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Updateautor([FromRoute] int id, [FromBody] Autor model)
    {
      await _autorRepository.UpdateAutor(id, model);
      return Ok();
    }

  }
}
