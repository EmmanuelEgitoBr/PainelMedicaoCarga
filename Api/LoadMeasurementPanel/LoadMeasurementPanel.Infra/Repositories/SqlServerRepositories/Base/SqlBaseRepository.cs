using LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces.Base;
using LoadMeasurementPanel.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoadMeasurementPanel.Infra.Repositories.SqlServerRepositories.Base
{
    public class SqlBaseRepository<T> : ISqlBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SqlBaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<T> CreateAsync(T commandCreate)
        {
            await _applicationDbContext.Set<T>().AddAsync(commandCreate);
            _applicationDbContext.SaveChanges();
            return commandCreate;
        }

        public Task Delete(long Id)
        {
            _applicationDbContext.Remove(Id);
            _applicationDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _applicationDbContext.Set<T>().ToListAsync();
        }

        public T Update(T commandUpdate)
        {
            _applicationDbContext.Set<T>().Update(commandUpdate);
            _applicationDbContext.SaveChanges();
            return commandUpdate;
        }
    }
}
