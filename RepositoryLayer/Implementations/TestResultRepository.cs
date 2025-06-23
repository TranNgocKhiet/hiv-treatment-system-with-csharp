using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly TestResultDAO _testResultDao;

        public TestResultRepository(HivDbContext context)
        {
            _testResultDao = new TestResultDAO(context);
        }

        public void Add(TestResult result) => _testResultDao.Add(result);
        public void Delete(long id) => _testResultDao.Delete(id);
        public void Update(TestResult result) => _testResultDao.Update(result);
        public TestResult GetById(long id) => _testResultDao.GetById(id);
        public List<TestResult> GetAll() => _testResultDao.GetAll();
    }
}
