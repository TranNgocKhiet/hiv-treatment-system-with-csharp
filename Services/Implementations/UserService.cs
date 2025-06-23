using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user) => _userRepository.Add(user);
        public void Delete(int id) => _userRepository.Delete(id);
        public List<User> GetAll() => _userRepository.GetAll();
        public User GetById(int id) => _userRepository.GetById(id);
        public void Update(User user) => _userRepository.Update(user);
        public User Login(String username, String password)
        {
            List<User> users = _userRepository.GetAll();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password) ?? new User
            {
                Id = 0,
                FullName = "Unknown",
                Address = "Unknown",
            };
        }
    }
}
