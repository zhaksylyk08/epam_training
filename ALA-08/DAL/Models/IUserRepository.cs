using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void DeleteUser(User user);
        void UpdateUser(User user);
        IEnumerable<User> GetUsersByName(string name);
        IEnumerable<User> GetUsersByFirstLetterOfName(char firstletter);
        User GetUserWithAwards(int? id);
    }
}
