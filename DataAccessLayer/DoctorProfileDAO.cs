using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class DoctorProfileDAO
    {
        private readonly HivDbContext _context;

        public DoctorProfileDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(DoctorProfile profile) => _context.DoctorProfiles.Add(profile);
        public void Delete(long id)
        {
            var obj = _context.DoctorProfiles.Find(id);
            if (obj != null) _context.DoctorProfiles.Remove(obj);
        }
        public void Update(DoctorProfile profile) => _context.DoctorProfiles.Update(profile);
        public DoctorProfile? GetById(long id) => _context.DoctorProfiles.Find(id);
        public List<DoctorProfile> GetAll() => _context.DoctorProfiles.ToList();
    }
}
