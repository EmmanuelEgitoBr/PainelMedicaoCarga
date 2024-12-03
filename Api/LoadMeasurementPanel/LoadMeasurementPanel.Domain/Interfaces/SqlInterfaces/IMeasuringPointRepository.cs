using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces.Base;

namespace LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces
{
    public interface IMeasuringPointRepository : ISqlBaseRepository<MeasuringPoint>
    {
    }
}
