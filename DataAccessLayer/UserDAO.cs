using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UserDAO
    {
        private readonly HivDbContext _context;

        public UserDAO(HivDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var existing = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.FullName = user.FullName;
                existing.Address = user.Address;
                existing.Gender = user.Gender;
                existing.PhoneNumber = user.PhoneNumber;
                existing.Email = user.Email;
                existing.Password = user.Password;
                existing.DateOfBirth = user.DateOfBirth;

                _context.SaveChanges();
            }
        }


        public void Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
