using EscolaPetApi.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EscolaPetApi.Application.DTO.Pet;
public class CreatePetDTO
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre {2} a {1} caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo idade é obrigatorio")]
    [Range(1, 30, ErrorMessage = "Idade do animal deve estar entre {1} e {2} anos")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "O campo especie é obrigatorio")]
    public Especie Especie { get; set; }

    [Required(ErrorMessage = "Informe um tutor")]
    public int TutorId { get; set; }
}
