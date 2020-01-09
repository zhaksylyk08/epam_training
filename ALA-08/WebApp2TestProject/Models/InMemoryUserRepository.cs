using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp2TestProject.Models
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _db = new List<User>();

        public void AddUser(User user)
        {
            _db.Add(user);
        }

        public User GetUserById(int id)
        {
            return _db.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.ToList();
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            return _db.Where(u => u.Name == name);
        }

        public IEnumerable<User> GetUsersByFirstLetterOfName(char firstLetter)
        {
            return _db.Where(u => u.Name.Substring(0, 1) == firstLetter.ToString());
        }

        public User GetUserWithAwards(int? id)
        {
            var userWithAwards = _db.FirstOrDefault(u => u.UserId == id);

            return userWithAwards;
        }

        public void DeleteUser(User user)
        {
            _db.Remove(user);
        }

        public void UpdateUser(User userToUpdate)
        {
            foreach (User user in _db)
            {
                if (user.UserId == userToUpdate.UserId)
                {
                    _db.Remove(user);
                    _db.Add(userToUpdate);
                }
            }
        }
    }
}

