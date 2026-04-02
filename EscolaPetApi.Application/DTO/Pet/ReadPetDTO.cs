using EscolaPetApi.Domain.Models.Enums;

namespace EscolaPetApi.Application.DTO.Pet;
public class ReadPetDTO
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public Especie Especie { get; set; }
}
