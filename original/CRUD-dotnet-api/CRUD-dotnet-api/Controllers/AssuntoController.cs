using Basisti_Client.Data;
using Basisti_Client.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Basisti_Client.Controllers
{
  /// <summary>
  /// Controller responsável por manipular dados de assuntos
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class AssuntoController : ControllerBase
  {
    private readonly AssuntoRepository _assuntoRepository;
    private readonly LivroAssuntoRepository _livroAssuntoRepository;
    public AssuntoController(AssuntoRepository assuntoRepository, LivroAssuntoRepository livroAssuntoRepository)
    {
      _assuntoRepository = assuntoRepository;
      _livroAssuntoRepository = livroAssuntoRepository;

    }

    /// <summary>
    /// Método responsável por incluir novo assunto
    /// </summary>
    /// <param name="model">Assunto</param>
    /// <returns>StatusCode</returns>
    [HttpPost]
    public async Task<ActionResult> AddAssunto([FromBody] Assunto model)
    {
      await _assuntoRepository.AddAssuntoAsync(model);
      return Ok();
    }
    /// <summary>
    /// Método responsável por retornar assuntos cadastrados
    /// </summary>
    /// <returns>List<Assunto></returns>
    [HttpGet]
    public async Task<ActionResult> GetAllAssuntos()
    {
      var assuntos = await _assuntoRepository.GetAllAssuntosAsync();
     
      return Ok(assuntos);
    }
    /// <summary>
    /// Método responsável por retornar um único assunto pelo seu código
    /// </summary>
    /// <param name="id">Código do assunto</param>
    /// <returns>Assunto</returns>
    [HttpGet("{codAs}")]
    public async Task<ActionResult> GetAssuntoById([FromRoute] int codAs)
    {
      var assunto = await _assuntoRepository.GetAssuntoByIdAsync(codAs);


      return Ok(assunto);
    }
    /// <summary>
    /// Método responsável por excluir um assunto
    /// </summary>
    /// <param name="id">Código do assunto</param>
    /// <returns>StatusCode</returns>
    [HttpDelete("{codAs}")]
    public async Task<ActionResult> DeleteAssunto([FromRoute] int codAs)
    {
      await _livroAssuntoRepository.DeleteLivro_AssuntoByAssuntoAsync(codAs);
      await _assuntoRepository.DeleteAssuntoAsync(codAs);
      return Ok();
    }
    /// <summary>
    /// Método responsável por atualizar um registro de assunto.
    /// </summary>
    /// <param name="id">Código do assunto</param>
    /// <param name="model">Assunto</param>
    /// <returns>StatusCode</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAssunto([FromRoute] int id, [FromBody] Assunto model)
    {
      await _assuntoRepository.UpdateAssunto(id, model);
      return Ok();
    }

  }
}
