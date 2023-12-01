﻿using eShop.Identity.DbContexts;
using eShop.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;

        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }

        public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(e => e.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}