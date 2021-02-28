using LinguaFluency.Domain.ServiceIntefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LinguaFluency.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public string PasswordToHash(string password)
        {
            SHA256 hash = SHA256.Create();
            var returnPassword = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));

            return returnPassword;
        }
    }
}
