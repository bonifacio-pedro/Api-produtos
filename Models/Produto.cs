using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIProdutos.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(100)]
    public string? Tipo { get; set; }

    [Required]
    [StringLength(15)]
    public string? Tamanho { get; set; }

    [Required]
    [StringLength(150)]
    public string? Descricao { get; set; }
    public int Estoque { get; set; }
    public double Valor { get; set; }
}
