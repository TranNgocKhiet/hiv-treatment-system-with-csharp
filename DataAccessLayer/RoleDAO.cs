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

        public void Add(Role role) => _context.Roles.Add(role);
        public void Delete(long id)
        {
            var role = _context.Roles.Find(id);
            if (role != null) _context.Roles.Remove(role);
        }
        public void Update(Role role) => _context.Roles.Update(role);
        public Role? GetById(long id) => _context.Roles.Find(id);
        public List<Role> GetAll() => _context.Roles.ToList();
    }
}