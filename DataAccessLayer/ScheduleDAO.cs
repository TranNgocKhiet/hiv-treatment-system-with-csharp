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

        public void Add(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges(); 
        }

        public void Delete(long id)
        {
            var obj = _context.Schedules.Find(id);
            if (obj != null)
            {
                _context.Schedules.Remove(obj);
                _context.SaveChanges(); 
            }
        }

        public void Update(Schedule schedule)
        {
            var existing = _context.Schedules.Find(schedule.Id);
            if (existing != null)
            {
                existing.Type = schedule.Type;
                existing.RoomCode = schedule.RoomCode;
                existing.ActiveStatus = schedule.ActiveStatus;
                existing.RequestStatus = schedule.RequestStatus;
                existing.Date = schedule.Date;
                existing.Slot = schedule.Slot;
                existing.DoctorId = schedule.DoctorId;
                existing.PatientId = schedule.PatientId;

                _context.SaveChanges();
            }
        }    
        
        public Schedule? GetById(long id) => _context.Schedules.Find(id);
        public List<Schedule> GetAll() => _context.Schedules.ToList();
    }
}
