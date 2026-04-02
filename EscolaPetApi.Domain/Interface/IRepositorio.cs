using System.Linq.Expressions;

namespace EscolaPetApi.Domain.Interface;
public interface IRepositorio<T>
{
    Task<IEnumerable<T>> BuscarTodosAsync();
    Task<T> BuscarPorIdAsync(Expression<Func<T, bool>> obj);
    Task<T> AdicionarAsync(T obj);
    Task<T> AtualizarAsync(T obj);
    Task<bool> ApagarAsync(int id);
}
