using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Domain.Interface;
public interface IEscolaPet : IRepositorio<EscolaPet>
{
    Task<EscolaPet> BuscarEscolaComtutores(int id);
}
