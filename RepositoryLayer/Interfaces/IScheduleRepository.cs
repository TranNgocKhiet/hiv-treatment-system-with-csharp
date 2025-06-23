using BusinessObjects;

namespace RepositoryLayer
{
    public interface IScheduleRepository
    {
        void Add(Schedule schedule);
        void Delete(long id);
        void Update(Schedule schedule);
        Schedule GetById(long id);
        List<Schedule> GetAll();
    }
}
