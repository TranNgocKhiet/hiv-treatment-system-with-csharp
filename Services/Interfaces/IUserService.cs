using BusinessObjects;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Add(User customer);
        void Update(User customer);
        void Delete(long id);
        User? GetById(long id);
        List<User> GetAll();
        User Login(String username, String password);

    }
}
