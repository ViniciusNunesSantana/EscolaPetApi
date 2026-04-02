using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models;
using EscolaPetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaPetApi.Infrastructure.Repositorio;
public class TutorRepositorio : Repositorio<Tutor>, ITutor
{
    public TutorRepositorio(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<Tutor> BuscarTutorComPets(int id)
    {
        return await _appDbContext.Tutores
            .Include(t => t.Pets)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
