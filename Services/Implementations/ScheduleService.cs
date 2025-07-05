using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public void Add(Schedule schedule) => _scheduleRepository.Add(schedule);
        public void Delete(long id) => _scheduleRepository.Delete(id);
        public Schedule GetById(long id) => _scheduleRepository.GetById(id);
        public List<Schedule> GetAll() => _scheduleRepository.GetAll();
        public void Update(Schedule schedule) => _scheduleRepository.Update(schedule);

        public List<Schedule> GetWherePatientNull()
        {
            return _scheduleRepository.GetAll().Where(s => s.PatientId is null).ToList();
        }

        public List<Schedule> GetWherePatientNotNull()
        {
            return _scheduleRepository.GetAll().Where(s => s.PatientId is not null).ToList();
        }

        public Schedule? GetByDateAndSlot(DateTime date, TimeSpan slot)
        {
            var allSchedules = _scheduleRepository.GetAll();
            return allSchedules
                .FirstOrDefault(s => s.Date == date.Date && s.Slot == slot && s.PatientId == null);
        }

        public Schedule? GetByPatientId(long patientId)
        {
            return _scheduleRepository.GetAll()
                .FirstOrDefault(s => s.PatientId == patientId);
        }

        public List<Schedule> GetAvailableSchedulesByDate(DateTime date)
        {
            return _scheduleRepository.GetAll()
                .Where(s => s.Date == date.Date && s.PatientId == null)
                .OrderBy(s => s.Slot)
                .ToList();
        }
    }
}
