using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using RedmineBot.Migrations;
using RedmineBot.Models;

namespace RedmineBot.Services
{
    public class BotDbContext : DbContext, IBotContext
    {
        static BotDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BotDbContext, Configuration>());
        }

        public BotDbContext() : base()
        {
            /*
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false
            */
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Redmine> Redmines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }

        public void Seed()
        {
            //    throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(string.Empty);
        }
    }
}