using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class UserServices:IUserRepository
    {
        private readonly IUserRepository _userRepositry;
        public UserServices(IUserRepository userRepositry)
        {
            _userRepositry = userRepositry;
        }

        public List<User> GetAllUser()
        {
            return _userRepositry.GetAllUser();
        }
        public User GetUser(int id)
        {
            //return JsonConvert.DeserializeObject<User>(obj1);
            return _userRepositry.GetUser(id);
        }


        public User Create(User user)
        {

            _userRepositry.Create(user);

            return user;
        }
        public void Update(int id, User userIn)
        {
            _userRepositry.Update(id, userIn);
        }
        public void Remove(User userIn)
        {
            _userRepositry.Remove(userIn);

        }


    }
}
