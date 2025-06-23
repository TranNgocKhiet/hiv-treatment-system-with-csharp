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

        public void Add(HealthRecord record) => _context.HealthRecords.Add(record);
        public void Delete(long id)
        {
            var obj = _context.HealthRecords.Find(id);
            if (obj != null) _context.HealthRecords.Remove(obj);
        }
        public void Update(HealthRecord record) => _context.HealthRecords.Update(record);
        public HealthRecord? GetById(long id) => _context.HealthRecords.Find(id);
        public List<HealthRecord> GetAll() => _context.HealthRecords.ToList();
    }
}