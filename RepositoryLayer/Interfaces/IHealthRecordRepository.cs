using BusinessObjects;

namespace RepositoryLayer
{
    public interface IHealthRecordRepository
    {
        void Add(HealthRecord record);
        void Delete(long id);
        void Update(HealthRecord record);
        HealthRecord GetById(long id);
        List<HealthRecord> GetAll();
    }
}
