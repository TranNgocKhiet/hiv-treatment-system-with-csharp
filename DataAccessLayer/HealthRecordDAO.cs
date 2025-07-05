using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class HealthRecordDAO
    {
        private readonly HivDbContext _context;

        public HealthRecordDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(HealthRecord record)
        {
            _context.HealthRecords.Add(record);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.HealthRecords.Find(id);
            if (obj != null)
            {
                _context.HealthRecords.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Update(HealthRecord record)
        {
            var existing = _context.HealthRecords.FirstOrDefault(r => r.Id == record.Id);
            if (existing != null)
            {
                existing.HivStatus = record.HivStatus;
                existing.BloodType = record.BloodType;
                existing.TreatmentStatus = record.TreatmentStatus;
                existing.Weight = record.Weight;
                existing.Height = record.Height;
                existing.ScheduleId = record.ScheduleId;
                existing.RegimenId = record.RegimenId;

                _context.SaveChanges();
            }
        }

        public HealthRecord? GetById(long id) => _context.HealthRecords.Find(id);
        public List<HealthRecord> GetAll() => _context.HealthRecords.ToList();
    }
}