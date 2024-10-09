using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os livros do banco de dados
  /// </summary>
  [Table("Livro")]
  public class Livro
  {
    /// <summary>
    /// Chave da tabela
    /// </summary>
    [Key]
    [Required]
    public int Codl { get; set; }
    /// <summary>
    /// Título do livro
    /// </summary>
    ///
    [Required]
    [StringLength(40)]

    public string Titulo { get; set; }
    /// <summary>
    /// Editora do livro
    /// </summary>
    [Required]
    [StringLength(40)]
    public string Editora { get; set; }
    /// <summary>
    /// Edição do livro
    /// </summary>
    [Required]
    public int Edicao { get; set; }
    /// <summary>
    /// Ano de publicação do livro
    /// </summary>
    [Required]
    public string AnoPublicacao { get; set; }

    [NotMapped]
    public string AutoresStr { get; set; }

    [NotMapped]
    public string AssuntosStr { get; set; }

    [NotMapped]
    public string ValoresStr { get; set; }


    [NotMapped]
    public List<Autor> Autores {  get; set; }

    [NotMapped]
    public List<Assunto> Assuntos { get; set; }

    [JsonIgnore]
    /// <summary>
    /// Contem a lista de valores por forma de compra relacionado ao livro
    /// </summary>
    public ICollection<Livro_FormaCompra> Livro_FormaCompra { get; set; }

    [JsonIgnore]
    /// <summary>
    /// Contem a lista de assuntos relacionado ao livro
    /// </summary>
    public ICollection<Livro_Assunto> Livro_Assunto { get; set; }
    
    [JsonIgnore]
    /// <summary>
    /// Contem a lista de autores relacionado ao livro
    /// </summary>
    public ICollection<Livro_Autor> Livro_Autores { get; set; }

    /// <summary>
    /// Construtor padrão incializando as variáveis 
    /// </summary>
    public Livro()
    {
      AssuntosStr = string.Empty;
      ValoresStr = string.Empty;
      AutoresStr = string.Empty;
      Titulo = string.Empty;
      Editora = string.Empty;
      AnoPublicacao = string.Empty;
      Livro_Assunto = new List<Livro_Assunto>();
      Livro_Autores = new List<Livro_Autor>();
      Livro_FormaCompra = new List<Livro_FormaCompra>();  
      Autores = new List<Autor>();
      Assuntos = new List<Assunto>();
    }

  }
}
