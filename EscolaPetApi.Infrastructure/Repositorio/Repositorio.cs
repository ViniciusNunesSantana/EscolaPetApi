using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EscolaPetApi.Infrastructure.Repositorio;
public class Repositorio<T> : IRepositorio<T> where T : class, IEntidade
{
    protected readonly AppDbContext _appDbContext;

    public Repositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<T>> BuscarTodosAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> BuscarPorIdAsync(Expression<Func<T, bool>> obj)
    {
        return await _appDbContext.Set<T>().FirstOrDefaultAsync(obj);
    }

    public async Task<T> AdicionarAsync(T obj)
    {
        await _appDbContext.Set<T>().AddAsync(obj);
        await _appDbContext.SaveChangesAsync();
        return obj;
    }

    public async Task<T> AtualizarAsync(T obj)
    {
        _appDbContext.Set<T>().Update(obj);
        await _appDbContext.SaveChangesAsync();
        return obj;
    }

    public async Task<bool> ApagarAsync(int id)
    {
        T obj = await _appDbContext.Set<T>().FindAsync(id);

        if(obj is null)
            return false;

        _appDbContext.Set<T>().Remove(obj);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
