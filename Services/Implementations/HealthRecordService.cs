using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;

        public HealthRecordService(IHealthRecordRepository healthRecordRepository)
        {
            _healthRecordRepository = healthRecordRepository;
        }

        public void Add(HealthRecord record) => _healthRecordRepository.Add(record);
        public void Delete(long id) => _healthRecordRepository.Delete(id);
        public HealthRecord GetById(long id) => _healthRecordRepository.GetById(id);
        public List<HealthRecord> GetAll() => _healthRecordRepository.GetAll();
        public void Update(HealthRecord record) => _healthRecordRepository.Update(record);
        public HealthRecord GetByScheduleId(long? scheduleId)
        {
            return _healthRecordRepository.GetAll()
                .FirstOrDefault(hr => hr.ScheduleId == scheduleId);
        }
    }
}
