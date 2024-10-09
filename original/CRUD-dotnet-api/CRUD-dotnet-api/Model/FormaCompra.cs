using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar as formas de compra de um livro do banco de dados
  /// </summary>
  [Table("FormaCompra")]
  public class FormaCompra
  {
    /// <summary>
    /// Chave da tabela
    /// </summary>
    [Key]    
    public int CodForm { get; set; }

    /// <summary>
    /// Nome do autor
    /// </summary>    
    [Required]    
    public string Descricao { get; set; }

   
    /// <summary>
    /// Construtor padrão incializando as variáveis 
    /// </summary>
    public FormaCompra() {
      Descricao = string.Empty;
    }

  }
}
