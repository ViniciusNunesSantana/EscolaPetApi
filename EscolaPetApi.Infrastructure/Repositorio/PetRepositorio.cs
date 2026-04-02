using EscolaPetApi.Domain.Models;
using EscolaPetApi.Infrastructure.Data;

namespace EscolaPetApi.Infrastructure.Repositorio;
public class PetRepositorio : Repositorio<Pet>
{
    public PetRepositorio(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
