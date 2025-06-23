using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Add(Role role) => _roleRepository.Add(role);

        public void Delete(int id) => _roleRepository.Delete(id);

        public Role GetById(int id) => _roleRepository.GetById(id);

        public List<Role> GetAll() => _roleRepository.GetAll();

        public void Update(Role role) => _roleRepository.Update(role);
    }
}
