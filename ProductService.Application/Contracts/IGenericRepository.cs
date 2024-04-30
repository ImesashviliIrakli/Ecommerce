using ProductService.Application.Dtos;

namespace ProductService.Application.Contracts;

public interface IGenericRepository<T>
{
    public Task<List<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task<T> Add(T entity);
    public Task<T> Update(T entity);
    public Task<bool> Delete(Guid id);
    public Task<bool> DeleteRange(List<Guid> ids);
}
