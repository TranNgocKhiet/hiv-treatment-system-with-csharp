using BusinessObjects;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Add(User customer);
        void Update(User customer);
        void Delete(int id);
        User GetById(int id);
        List<User> GetAll();
        User Login(String username, String password);

    }
}
