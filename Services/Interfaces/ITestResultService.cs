using BusinessObjects;

namespace Services.Interfaces
{
    public interface ITestResultService
    {
        void Add(TestResult result);
        void Update(TestResult result);
        void Delete(int id);
        TestResult GetById(int id);
        List<TestResult> GetAll();
    }
}
