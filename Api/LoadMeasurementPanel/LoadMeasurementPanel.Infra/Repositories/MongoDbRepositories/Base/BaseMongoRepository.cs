using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces.Base;
using LoadMeasurementPanel.Infra.Configurations;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LoadMeasurementPanel.Infra.Repositories.MongoDbRepositories.Base
{
    public abstract class BaseMongoRepository<T> : IBaseMongoRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;
        protected readonly IMongoDatabase _database;

        public BaseMongoRepository(MongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _database = database;
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> filterExpression)
            => await _collection.FindOneAndDeleteAsync(filterExpression);

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
            => await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

        public async Task UpdateAsync(T newClass, Guid id, CancellationToken cancellationToken = default)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection!.ReplaceOneAsync(filter, newClass, cancellationToken: cancellationToken);
        }
    }
}
