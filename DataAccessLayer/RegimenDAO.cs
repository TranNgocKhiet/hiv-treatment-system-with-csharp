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

        public void Add(Regimen regimen) => _context.Regimens.Add(regimen);
        public void Delete(long id)
        {
            var obj = _context.Regimens.Find(id);
            if (obj != null) _context.Regimens.Remove(obj);
        }
        public void Update(Regimen regimen) => _context.Regimens.Update(regimen);
        public Regimen? GetById(long id) => _context.Regimens.Find(id);
        public List<Regimen> GetAll() => _context.Regimens.ToList();
    }
}

