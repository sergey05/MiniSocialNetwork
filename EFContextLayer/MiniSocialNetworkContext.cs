using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DomainModels;
using EFContextLayer.Migrations;

namespace EFContextLayer
{
    public class MiniSocialNetworkContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Manager>().ToTable("Manager");
            //modelBuilder.Entity<Trainer>().ToTable("Trainer");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Person>().HasOptional(p => p.PassportData)
            //                   .WithRequired(o => o.Person)
            //                   .WillCascadeOnDelete();
            //modelBuilder.Entity<Person>().HasOptional(p => p.User)
            //                   .WithRequired(o => o.Person)
            //                   .WillCascadeOnDelete();
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MiniSocialNetworkContext, Configuration>());
        }
    }
}
