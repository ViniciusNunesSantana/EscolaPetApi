using EscolaPetApi.Application.DTO.Pet;
using System.ComponentModel.DataAnnotations;

namespace EscolaPetApi.Application.DTO.Tutor;
public class TutorComPetsDTO
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public ICollection<ReadPetDTO> Pets { get; set; } = new List<ReadPetDTO>();

}
