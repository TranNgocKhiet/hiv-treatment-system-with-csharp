using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleDAO _scheduleDao;

        public ScheduleRepository(HivDbContext context)
        {
            _scheduleDao = new ScheduleDAO(context);
        }

        public void Add(Schedule schedule) => _scheduleDao.Add(schedule);
        public void Delete(long id) => _scheduleDao.Delete(id);
        public void Update(Schedule schedule) => _scheduleDao.Update(schedule);
        public Schedule GetById(long id) => _scheduleDao.GetById(id);
        public List<Schedule> GetAll() => _scheduleDao.GetAll();
    }
}
