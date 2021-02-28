using LinguaFluency.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
    }
}
