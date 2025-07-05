using BusinessObjects;

namespace Services.Interfaces
{
    public interface IScheduleService
    {
        void Add(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(long id);
        Schedule? GetById(long id);
        List<Schedule> GetAll();
        List<Schedule> GetWherePatientNull();
        List<Schedule> GetWherePatientNotNull();
        Schedule? GetByDateAndSlot(DateTime date, TimeSpan slot);
        Schedule? GetByPatientId(long patientId);

        List<Schedule> GetAvailableSchedulesByDate(DateTime date);

    }
}
