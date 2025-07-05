using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public void Add(User user) => _userRepository.Add(user);
        public void Delete(long id) => _userRepository.Delete(id);
        public List<User> GetAll() => _userRepository.GetAll();
        public User GetById(long id) => _userRepository.GetById(id);
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
        public List<User> GetAllDoctors()
        {
            var doctorRole = _roleRepository.GetById(2);
            if (doctorRole == null) return new List<User>();

            return _userRepository.GetAll()
                .Where(u => u.RoleId == doctorRole.Id)
                .ToList();
        }

        public List<User> GetDoctorsByName(string keyword)
        {
            return _userRepository.GetAll()
                .Where(u => u.RoleId == 2 &&
                            u.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
