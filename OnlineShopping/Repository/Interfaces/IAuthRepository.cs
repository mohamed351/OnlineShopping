using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<AppUser> Registration(AppUser user, string password);
        Task<AppUser> Login(string userName, string password);
        Task<bool> UserExist(string userName);
    }
}
