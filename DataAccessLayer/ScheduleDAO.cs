using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ScheduleDAO
    {
        private readonly HivDbContext _context;

        public ScheduleDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(Schedule schedule) => _context.Schedules.Add(schedule);
        public void Delete(long id)
        {
            var obj = _context.Schedules.Find(id);
            if (obj != null) _context.Schedules.Remove(obj);
        }
        public void Update(Schedule schedule) => _context.Schedules.Update(schedule);
        public Schedule? GetById(long id) => _context.Schedules.Find(id);
        public List<Schedule> GetAll() => _context.Schedules.ToList();
    }
}
