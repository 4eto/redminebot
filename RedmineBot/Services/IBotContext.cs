using System;
using System.Data.Entity;
using System.Threading.Tasks;
using RedmineBot.Models;

namespace RedmineBot.Services
{
    interface IBotContext : IDisposable
    {
        DbSet<Redmine> Redmines { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Issue> Issues { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

        void Seed();
    }
}
