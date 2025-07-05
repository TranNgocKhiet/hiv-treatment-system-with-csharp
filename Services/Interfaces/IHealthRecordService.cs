using BusinessObjects;

namespace Services.Interfaces
{
    public interface IHealthRecordService
    {
        void Add(HealthRecord record);
        void Update(HealthRecord record);
        void Delete(long id);
        HealthRecord? GetById(long id);
        List<HealthRecord> GetAll();
        HealthRecord GetByScheduleId(long? scheduleId);

    }
}
