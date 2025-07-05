using BusinessObjects;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        void Add(Role role);
        void Delete(long id);
        void Update(Role role);
        Role? GetById(long id);
        List<Role> GetAll();
    }
}
