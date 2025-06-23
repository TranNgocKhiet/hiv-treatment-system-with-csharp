using BusinessObjects;

namespace RepositoryLayer
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(long id);
        void Update(User user);
        User GetById(long id);
        List<User> GetAll();
    }
}
