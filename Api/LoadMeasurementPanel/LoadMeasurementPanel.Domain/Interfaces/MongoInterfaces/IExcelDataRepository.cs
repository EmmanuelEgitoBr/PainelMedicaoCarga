using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces.Base;

namespace LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces
{
    public interface IExcelDataRepository : IBaseMongoRepository<RegisterExcelData>
    {
    }
}
