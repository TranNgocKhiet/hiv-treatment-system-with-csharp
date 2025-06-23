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
        public void Delete(int id) => _testResultRepository.Delete(id);
        public TestResult GetById(int id) => _testResultRepository.GetById(id);
        public List<TestResult> GetAll() => _testResultRepository.GetAll();
        public void Update(TestResult result) => _testResultRepository.Update(result);
    }
}
