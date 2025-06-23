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

        public void Add(TestResult result) => _context.TestResults.Add(result);
        public void Delete(long id)
        {
            var obj = _context.TestResults.Find(id);
            if (obj != null) _context.TestResults.Remove(obj);
        }
        public void Update(TestResult result) => _context.TestResults.Update(result);
        public TestResult? GetById(long id) => _context.TestResults.Find(id);
        public List<TestResult> GetAll() => _context.TestResults.ToList();
    }
}
