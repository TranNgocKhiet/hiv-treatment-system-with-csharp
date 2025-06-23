using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly HealthRecordDAO _healthRecordDao;

        public HealthRecordRepository(HivDbContext context)
        {
            _healthRecordDao = new HealthRecordDAO(context);
        }

        public void Add(HealthRecord record) => _healthRecordDao.Add(record);
        public void Delete(long id) => _healthRecordDao.Delete(id);
        public void Update(HealthRecord record) => _healthRecordDao.Update(record);
        public HealthRecord GetById(long id) => _healthRecordDao.GetById(id);
        public List<HealthRecord> GetAll() => _healthRecordDao.GetAll();
    }
}
