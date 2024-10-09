using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os assuntos do banco de dados
  /// </summary>
  [Table("Assunto")]
  public class Assunto
  {
    /// <summary>
    /// Chave da tabela
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodAs { get; set; }
    /// <summary>
    /// Descrição do assunto
    /// </summary>    
    [Required]
    [StringLength(20)]
    public string Descricao { get; set; }
       

    /// <summary>
    /// Construtor padrão incializando as variáveis 
    /// </summary>
    public Assunto() {
      Descricao =  string.Empty;
    }
  }
}
