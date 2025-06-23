using BusinessObjects;
using DataAccess;
using DataAccessLayer;

namespace RepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private static UserRepository _instance;
        private static readonly object _lock = new object();

        private readonly UserDAO _userDao;

        public UserRepository(HivDbContext context)
        {
            _userDao = new UserDAO(context);
        }

        public static UserRepository GetInstance(HivDbContext context)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserRepository(context);
                    }
                }
            }
            return _instance;
        }

        public void Add(User user)
        {
            _userDao.Add(user);
        }

        public void Delete(long id)
        {
            _userDao.Delete(id);
        }

        public void Update(User user)
        {
            _userDao.Update(user);
        }

        public User GetById(long id)
        {
            return _userDao.GetById(id);
        }

        public List<User> GetAll()
        {
            return _userDao.GetAll();
        }
    }
}
