using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services
{
    public interface IUserRepository
    {
        User GetUser(int id);
        List<User> GetAllUser();
        User Create(User user);
        void Update(int id, User userIn);
        void Remove(User userIn);
    }
}
