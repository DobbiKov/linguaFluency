using LinguaFluency.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinguaFluency.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ActionResult<IEnumerable<User>>> GetUsersAsync();
        Task<ActionResult<User>> GetUserAsync(Guid id);
        Task<IActionResult> UpdateUserAsync(Guid id, User user);
        Task<ActionResult<User>> CreateUserAsync(User user);
        Task<ActionResult<User>> DeleteUserAsync(Guid id);
    }
}
