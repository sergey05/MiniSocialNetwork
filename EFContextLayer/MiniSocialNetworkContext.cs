using System.Data.Entity;
using EFContextLayer.Migrations;
namespace EFContextLayer
{
    public class MiniSocialNetworkContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
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
