using System.Linq.Expressions;

namespace eShop.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        #region GET
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(int id);
        #endregion
    }
}
