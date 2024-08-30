using XerifeTv.CMS.Models.Abstractions.Entities;

namespace XerifeTv.CMS.Models.Abstractions.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
  public virtual Task<IEnumerable<T>> GetAsync()
  {
    throw new NotImplementedException();
  }

  public virtual Task<T?> GetAsync(string id)
  {
    throw new NotImplementedException();
  }

  public virtual Task CreateAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public virtual Task UpdateAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public virtual Task DeleteAsync(string id)
  {
    throw new NotImplementedException();
  }
}
