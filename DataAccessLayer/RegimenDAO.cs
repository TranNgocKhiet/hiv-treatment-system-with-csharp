using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class RegimenDAO
    {
        private readonly HivDbContext _context;

        public RegimenDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(Regimen regimen)
        {
            _context.Regimens.Add(regimen);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.Regimens.Find(id);
            if (obj != null)
            {
                _context.Regimens.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Update(Regimen regimen)
        {
            var existing = _context.Regimens.FirstOrDefault(r => r.Id == regimen.Id);
            if (existing != null)
            {
                existing.Components = regimen.Components;
                existing.RegimenName = regimen.RegimenName;
                existing.Description = regimen.Description;
                existing.Indications = regimen.Indications;
                existing.Contraindications = regimen.Contraindications;
                existing.DoctorId = regimen.DoctorId;

                _context.SaveChanges();
            }
        }

        public Regimen? GetById(long id) => _context.Regimens.Find(id);
        public List<Regimen> GetAll() => _context.Regimens.ToList();
    }
}

