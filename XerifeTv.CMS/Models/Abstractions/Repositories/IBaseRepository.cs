using XerifeTv.CMS.Models.Abstractions.Entities;

namespace XerifeTv.CMS.Models.Abstractions.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
  Task<IEnumerable<T>> GetAsync();
  Task<T?> GetAsync(string id);
  Task CreateAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(string id);
}
