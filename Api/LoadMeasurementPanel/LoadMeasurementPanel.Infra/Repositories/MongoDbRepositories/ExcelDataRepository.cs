using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces;
using LoadMeasurementPanel.Infra.Configurations;
using LoadMeasurementPanel.Infra.Repositories.MongoDbRepositories.Base;

namespace LoadMeasurementPanel.Infra.Repositories.MongoDbRepositories
{
    public class ExcelDataRepository : BaseMongoRepository<RegisterExcelData>, IExcelDataRepository
    {
        public ExcelDataRepository(MongoDbSettings settings) : base(settings)
        {
        }
    }
}
