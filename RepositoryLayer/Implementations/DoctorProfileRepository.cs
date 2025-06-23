using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class DoctorProfileRepository : IDoctorProfileRepository
    {
        private readonly DoctorProfileDAO _doctorDao;

        public DoctorProfileRepository(HivDbContext context)
        {
            _doctorDao = new DoctorProfileDAO(context);
        }

        public void Add(DoctorProfile profile) => _doctorDao.Add(profile);
        public void Delete(long id) => _doctorDao.Delete(id);
        public void Update(DoctorProfile profile) => _doctorDao.Update(profile);
        public DoctorProfile GetById(long id) => _doctorDao.GetById(id);
        public List<DoctorProfile> GetAll() => _doctorDao.GetAll();
    }
}
