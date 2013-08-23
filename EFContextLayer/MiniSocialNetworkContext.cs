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

            modelBuilder.Entity<User>()
                        .HasMany<Message>(r => r.InboxMessages)
                        .WithMany(u => u.Recipients)
                        .Map(m =>
                        {
                            m.ToTable("UserMessages");
                            m.MapLeftKey("UserId");
                            m.MapRightKey("MessageId");
                        });

            modelBuilder.Entity<User>()
                        .HasMany<User>(r => r.MyBlackList)
                        .WithMany(u => u.DeniedAccessUsers)
                        .Map(m =>
                        {
                            m.ToTable("UserBlackList");
                            m.MapLeftKey("UserId");
                            m.MapRightKey("BlackListedUserId");
                        });


            modelBuilder.Entity<User>()
                        .HasMany<Subscription>(r => r.Subscribers)
                        .WithRequired(o => o.User).HasForeignKey(o=>o.UserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany<Subscription>(r => r.MySubscriptions)
                        .WithRequired(o => o.Subscriber).HasForeignKey(o => o.SubscriberId);

            modelBuilder.Entity<Subscription>().HasKey(o => new { o.SubscriberId, o.UserId });

            modelBuilder.Entity<Comment>()
                        .HasRequired(p => p.Post)
                        .WithMany(b => b.Comments);

            modelBuilder.Entity<Post>()
                        .HasRequired(p => p.Author)
                        .WithMany(o => o.MyPosts);

            modelBuilder.Entity<RePost>()
                        .HasOptional(p => p.Owner)
                        .WithMany(o => o.MyRePosts);

            modelBuilder.Entity<RePost>().ToTable("RePost");
        }

        public static void SetInitializer()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MiniSocialNetworkContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<MiniSocialNetworkContext>());
        }
    }
}
