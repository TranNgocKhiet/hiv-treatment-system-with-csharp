using BusinessObjects;

namespace Services.Interfaces
{
    public interface IHealthRecordService
    {
        void Add(HealthRecord record);
        void Update(HealthRecord record);
        void Delete(int id);
        HealthRecord GetById(int id);
        List<HealthRecord> GetAll();
    }
}
