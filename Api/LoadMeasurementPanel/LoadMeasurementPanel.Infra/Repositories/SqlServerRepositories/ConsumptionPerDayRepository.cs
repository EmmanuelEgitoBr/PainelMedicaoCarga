using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces;
using LoadMeasurementPanel.Infra.Context;
using LoadMeasurementPanel.Infra.Repositories.SqlServerRepositories.Base;

namespace LoadMeasurementPanel.Infra.Repositories.SqlServerRepositories
{
    public class ConsumptionPerDayRepository(ApplicationDbContext applicationDbContext) : SqlBaseRepository<EnergyConsumptionPerDay>(applicationDbContext), IConsumptionPerDayRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    }
}
