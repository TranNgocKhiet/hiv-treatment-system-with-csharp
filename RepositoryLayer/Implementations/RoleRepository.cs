using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleDAO _roleDao;

        public RoleRepository(HivDbContext context)
        {
            _roleDao = new RoleDAO(context);
        }

        public void Add(Role role) => _roleDao.Add(role);
        public void Delete(long id) => _roleDao.Delete(id);
        public void Update(Role role) => _roleDao.Update(role);
        public Role GetById(long id) => _roleDao.GetById(id);
        public List<Role> GetAll() => _roleDao.GetAll();
    }
}
