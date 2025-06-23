using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class DoctorProfileService : IDoctorProfileService
    {
        private readonly IDoctorProfileRepository _doctorProfileRepository;

        public DoctorProfileService(IDoctorProfileRepository doctorProfileRepository)
        {
            _doctorProfileRepository = doctorProfileRepository;
        }

        public void Add(DoctorProfile doctor) => _doctorProfileRepository.Add(doctor);
        public void Delete(int id) => _doctorProfileRepository.Delete(id);
        public DoctorProfile GetById(int id) => _doctorProfileRepository.GetById(id);
        public List<DoctorProfile> GetAll() => _doctorProfileRepository.GetAll();
        public void Update(DoctorProfile doctor) => _doctorProfileRepository.Update(doctor);
    }
}
