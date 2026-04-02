using EscolaPetApi.Application.DTO.Tutor;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EscolaPetApi.Application.DTO.Escola;
public class CreateEscolaPetDTO
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome tem que ter de {2} a {1} caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo telefone é obrigatorio")]
    [Phone]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo endereço é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Endereço tem que ter de {2} a {1} caracteres")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email nome é obrigatorio")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

}
