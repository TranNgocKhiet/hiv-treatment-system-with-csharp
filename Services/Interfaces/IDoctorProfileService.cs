using BusinessObjects;

namespace Services.Interfaces
{
    public interface IDoctorProfileService
    {
        void Add(DoctorProfile doctor);
        void Update(DoctorProfile doctor);
        void Delete(long id);
        DoctorProfile? GetById(long id);
        List<DoctorProfile> GetAll();
    }
}
