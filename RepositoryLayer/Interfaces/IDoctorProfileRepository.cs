using BusinessObjects;

namespace RepositoryLayer
{
    public interface IDoctorProfileRepository
    {
        void Add(DoctorProfile profile);
        void Delete(long id);
        void Update(DoctorProfile profile);
        DoctorProfile GetById(long id);
        List<DoctorProfile> GetAll();
    }
}
