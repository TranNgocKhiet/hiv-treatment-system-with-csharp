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

        public void Add(DoctorProfile profile)
        {
            _context.DoctorProfiles.Add(profile);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.DoctorProfiles.Find(id);
            if (obj != null)
            {
                _context.DoctorProfiles.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Update(DoctorProfile profile)
        {
            var existing = _context.DoctorProfiles.FirstOrDefault(d => d.Id == profile.Id);
            if (existing != null)
            {
                existing.Qualifications = profile.Qualifications;
                existing.Background = profile.Background;
                existing.Biography = profile.Biography;
                existing.LicenseNumber = profile.LicenseNumber;
                existing.StartYear = profile.StartYear;

                _context.SaveChanges();
            }
        }


        public DoctorProfile? GetById(long id) => _context.DoctorProfiles.Find(id);
        public List<DoctorProfile> GetAll() => _context.DoctorProfiles.ToList();
    }
}
