using System.Linq.Expressions;

namespace LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces.Base
{
    public interface ISqlBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T commandCreate);
        Task Delete(long Id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T commandUpdate);
    }
}
