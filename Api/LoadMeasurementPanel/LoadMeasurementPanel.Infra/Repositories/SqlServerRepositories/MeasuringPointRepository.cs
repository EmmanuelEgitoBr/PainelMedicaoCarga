using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces;
using LoadMeasurementPanel.Infra.Context;
using LoadMeasurementPanel.Infra.Repositories.SqlServerRepositories.Base;

namespace LoadMeasurementPanel.Infra.Repositories.SqlServerRepositories
{
    public class MeasuringPointRepository(ApplicationDbContext applicationDbContext) : SqlBaseRepository<MeasuringPoint>(applicationDbContext), IMeasuringPointRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    }
}
