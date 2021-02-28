using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Domain.ServiceIntefraces
{
    public interface IUserService
    {
        string PasswordToHash(string password);
        string GenerateJWTToken(string username, string userId, string siteRoleId);
    }
}
