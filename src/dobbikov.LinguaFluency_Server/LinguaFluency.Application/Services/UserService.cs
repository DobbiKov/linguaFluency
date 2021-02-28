using LinguaFluency.Application.Exeptions;
using LinguaFluency.Domain.Interfaces;
using LinguaFluency.Domain.Models;
using LinguaFluency.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinguaFluency.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            var checkUserName = await _context.users.FirstOrDefaultAsync(x => x.Username == user.Username);

            if(checkUserName != null)
            {
                throw new BadRequestException("User with this username is exist.");
            }

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            var newUser = await _context.users.FirstOrDefaultAsync(x => x.Username == user.Username);

            return await GetUserAsync(newUser.Id);
        }

        public async Task<ActionResult<User>> DeleteUserAsync(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ActionResult<User>> GetUserAsync(Guid id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            return user;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<IActionResult> UpdateUserAsync(Guid id, User user)
        {
            if (id != user.Id)
            {
                throw new BadRequestException("id != user.Id");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                 throw new NotFoundException(nameof(User), id);
            }

            throw new BadRequestException("No Content.");
        }
    }
}
