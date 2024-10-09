using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basisti_Client.Model
{
  /// <summary>
  /// Entidade responsável por representar os valores de compra de um livro
  /// </summary>
  [Table("Livro_FormaCompra")]
  public class Livro_FormaCompra
  {
    [Key]
    [Required]
    public int Codl { get; set; }

    [Key]
    [Required]
    public int CodForm { get; set; }

    [NotMapped]
    public string NomeForma { get; set; }

    public double Valor { get; set; }

    public Livro_FormaCompra()
    {
      NomeForma = string.Empty;
    }

  }
}
