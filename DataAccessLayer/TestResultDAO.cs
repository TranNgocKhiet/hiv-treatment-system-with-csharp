using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class TestResultDAO
    {
        private readonly HivDbContext _context;

        public TestResultDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(TestResult result)
        {
            _context.TestResults.Add(result);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.TestResults.Find(id);
            if (obj != null)
            {
                _context.TestResults.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Update(TestResult result)
        {
            var existing = _context.TestResults.FirstOrDefault(r => r.Id == result.Id);
            if (existing != null)
            {
                existing.Unit = result.Unit;
                existing.Type = result.Type;
                existing.Result = result.Result;
                existing.Note = result.Note;
                existing.ExpectedResultTime = result.ExpectedResultTime;
                existing.ActualResultTime = result.ActualResultTime;
                existing.HealthRecordId = result.HealthRecordId;

                _context.SaveChanges();
            }
        }


        public TestResult? GetById(long id) => _context.TestResults.Find(id);
        public List<TestResult> GetAll() => _context.TestResults.ToList();
    }
}
