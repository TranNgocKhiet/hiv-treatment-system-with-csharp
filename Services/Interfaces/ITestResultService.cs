using BusinessObjects;

namespace Services.Interfaces
{
    public interface ITestResultService
    {
        void Add(TestResult result);
        void Update(TestResult result);
        void Delete(long id);
        TestResult? GetById(long id);
        List<TestResult> GetAll();
        List<TestResult> GetByHealthRecordId(long healthRecordId);
    }
}
