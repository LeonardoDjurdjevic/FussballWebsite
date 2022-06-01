using Fussball_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FussballWebsite.Models.DB {
        
    public interface IRepositoryDb {
        Task ConnectAsync();
        Task DisconnectAsync();
        Task<bool> Insert(User user);
        Task<bool> Delete(int user_id);
        Task<bool> ChangeUserData(int userID, User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(string user_id);
        Task<User> Login(String username, String password);
    }
}
