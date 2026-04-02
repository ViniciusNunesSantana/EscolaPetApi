using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models;
using EscolaPetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaPetApi.Infrastructure.Repositorio;
public class EscolaPetRepositorio : Repositorio<EscolaPet>, IEscolaPet
{
    public EscolaPetRepositorio(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<EscolaPet> BuscarEscolaComtutores(int id)
    {
        return await _appDbContext.EscolaPets
             .Include(e => e.Tutores)
             .FirstOrDefaultAsync(e => e.Id == id);
    }
}
