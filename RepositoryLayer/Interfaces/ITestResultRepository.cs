using BusinessObjects;

namespace RepositoryLayer
{
    public interface ITestResultRepository
    {
        void Add(TestResult result);
        void Delete(long id);
        void Update(TestResult result);
        TestResult GetById(long id);
        List<TestResult> GetAll();
    }
}
