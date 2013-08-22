using System.ComponentModel.DataAnnotations.Schema;
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
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Message>().Property(o => o.MessageId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Message>().HasKey(o=>o.MessageId);
            modelBuilder.Entity<User>()
                .HasMany<Message>(r => r.InboxMessages)
                .WithMany(u => u.Recipients)
                .Map(m =>
                {
                    m.ToTable("UserMessages");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("MessageId");
                    });

            modelBuilder.Entity<Comment>()
                        .HasRequired(p => p.Post)
                        .WithMany(b => b.Comments);

            modelBuilder.Entity<Post>()
                        .HasRequired(p => p.Author)
                        .WithMany(o => o.MyPosts);

            modelBuilder.Entity<RePost>()
                        .HasOptional(p => p.Owner)
                        .WithMany(o => o.MyRePosts);

            modelBuilder.Entity<BlackListUser>().ToTable("BlackListUser");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<RePost>().ToTable("RePost");
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MiniSocialNetworkContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MiniSocialNetworkContext>());
        }
    }
}
