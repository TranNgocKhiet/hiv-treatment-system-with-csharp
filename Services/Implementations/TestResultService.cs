using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TestResultService : ITestResultService
    {
        private readonly ITestResultRepository _testResultRepository;

        public TestResultService(ITestResultRepository testResultRepository)
        {
            _testResultRepository = testResultRepository;
        }

        public void Add(TestResult result) => _testResultRepository.Add(result);
        public void Delete(long id) => _testResultRepository.Delete(id);
        public TestResult GetById(long id) => _testResultRepository.GetById(id);
        public List<TestResult> GetAll() => _testResultRepository.GetAll();
        public void Update(TestResult result) => _testResultRepository.Update(result);

        public List<TestResult> GetByHealthRecordId(long healthRecordId)
        {
            return _testResultRepository.GetAll().Where(tr => tr.HealthRecordId == healthRecordId).ToList();
        }
    }
}
