using BusinessObjects;

namespace RepositoryLayer
{
    public interface IRoleRepository
    {
        void Add(Role role);
        void Delete(long id);
        void Update(Role role);
        Role GetById(long id);
        List<Role> GetAll();
    }
}
