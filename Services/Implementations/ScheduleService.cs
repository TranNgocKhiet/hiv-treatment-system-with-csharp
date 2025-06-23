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
        public void Delete(int id) => _scheduleRepository.Delete(id);
        public Schedule GetById(int id) => _scheduleRepository.GetById(id);
        public List<Schedule> GetAll() => _scheduleRepository.GetAll();
        public void Update(Schedule schedule) => _scheduleRepository.Update(schedule);
    }
}
