using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAuthorization.Entities;

namespace DataAuthorization.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
