using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
