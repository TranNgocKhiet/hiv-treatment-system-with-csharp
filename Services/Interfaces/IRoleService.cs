using BusinessObjects;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        void Add(Role role);
        void Delete(int id);
        void Update(Role role);
        Role GetById(int id);
        List<Role> GetAll();
    }
}
