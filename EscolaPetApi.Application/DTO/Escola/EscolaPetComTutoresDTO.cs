using EscolaPetApi.Application.DTO.Tutor;
using System.ComponentModel.DataAnnotations;

namespace EscolaPetApi.Application.DTO.Escola;
public class EscolaPetComTutoresDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<ReadTutorDTO> Tutores { get; set; } = new List<ReadTutorDTO>();

}
