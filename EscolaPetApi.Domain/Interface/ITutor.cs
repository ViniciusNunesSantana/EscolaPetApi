using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Domain.Interface;
public interface ITutor : IRepositorio<Tutor>
{
    Task<Tutor> BuscarTutorComPets(int id);
}
