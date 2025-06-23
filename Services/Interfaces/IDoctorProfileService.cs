using BusinessObjects;

namespace Services.Interfaces
{
    public interface IDoctorProfileService
    {
        void Add(DoctorProfile doctor);
        void Update(DoctorProfile doctor);
        void Delete(int id);
        DoctorProfile GetById(int id);
        List<DoctorProfile> GetAll();
    }
}
