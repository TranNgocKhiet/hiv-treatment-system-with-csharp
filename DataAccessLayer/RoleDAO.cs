using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class RoleDAO
    {
        private readonly HivDbContext _context;

        public RoleDAO(HivDbContext context)
        {
            _context = context;
        }

        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }

        public void Update(Role role)
        {
            var existing = _context.Roles.Find(role.Id);
            if (existing != null)
            {
                existing.RoleName = role.RoleName;
                _context.SaveChanges();
            }
        }


        public Role? GetById(long id) => _context.Roles.Find(id);
        public List<Role> GetAll() => _context.Roles.ToList();
    }
}