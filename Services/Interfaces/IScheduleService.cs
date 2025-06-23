using BusinessObjects;

namespace Services.Interfaces
{
    public interface IScheduleService
    {
        void Add(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(int id);
        Schedule GetById(int id);
        List<Schedule> GetAll();
    }
}
