using DAL.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly WebAppContext _webAppContext;

        public UserRepository(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }

        public void AddUser(User user)
        {
            _webAppContext.Users.Add(user);
            _webAppContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _webAppContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = _webAppContext.Users
                              .Include(user => user.UserAwards)
                                .ThenInclude(user => user.Award)
                              .OrderBy(user => user.Name)
                              .ToList();

            return result;
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            var result = _webAppContext.Users
                  .Include(user => user.UserAwards)
                    .ThenInclude(user => user.Award)
                  .Where(user => user.Name == name)
                  .OrderBy(user => user.Name)
                  .ToList();

            return result;
        }

        public IEnumerable<User> GetUsersByFirstLetterOfName(char firstLetter)
        {
            var result = _webAppContext.Users
                  .Include(user => user.UserAwards)
                    .ThenInclude(user => user.Award)
                  .Where(user => user.Name.Substring(0, 1) == firstLetter.ToString())
                  .OrderBy(user => user.Name)
                  .ToList();

            return result;
        }

        public User GetUserWithAwards(int? id)
        {
            var userWithAwards = _webAppContext.Users
                            .Include(user => user.UserAwards)
                                .ThenInclude(user => user.Award)
                            .FirstOrDefault(user => user.UserId == id);

            return userWithAwards;
        }

        public void DeleteUser(User user)
        {
            _webAppContext.Users.Remove(user);
            _webAppContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _webAppContext.Users.Update(user);
            _webAppContext.SaveChanges();
        }
    }
}
