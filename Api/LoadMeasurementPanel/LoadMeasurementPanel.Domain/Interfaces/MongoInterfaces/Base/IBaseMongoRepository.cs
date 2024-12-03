using System.Linq.Expressions;

namespace LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces.Base
{
    public interface IBaseMongoRepository<T>
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<T, bool>> filterExpression);
        Task<T> FindAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, Guid id, CancellationToken cancellationToken = default);
    }
}
