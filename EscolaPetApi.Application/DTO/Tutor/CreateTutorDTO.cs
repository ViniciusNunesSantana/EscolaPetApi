using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EscolaPetApi.Application.DTO.Pet;

namespace EscolaPetApi.Application.DTO.Tutor;
public class CreateTutorDTO
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo idade é obrigatorio")]
    [Range(18, 60, ErrorMessage = "Idade deve ser entre {1} a {2} anos")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "O campo telefone é obrigatorio")]
    [Phone]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo email é obrigatorio")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo endereço é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Endereço tem que ter de {2} a {1} caracteres")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe uma escola")]
    public int EscolaId { get; set; }


}
