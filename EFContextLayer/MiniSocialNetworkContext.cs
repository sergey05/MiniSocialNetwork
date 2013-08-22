﻿using System.Collections.Generic;
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
            modelBuilder.Entity<MessageRecipient>()
                        .HasKey(a => new { a.MessageId, a.RecipientId });

            modelBuilder.Entity<MessageRecipient>()
                        .HasRequired(mp => mp.Message)
                        .WithMany()
                        .HasForeignKey(p => p.MessageId).WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageRecipient>()
                        .HasRequired(p => p.Recipient)
                        .WithMany(b => b.InboxMessages);

            modelBuilder.Entity<Message>()
                        .HasRequired(p => p.Sender)
                        .WithMany(b => b.OutboxMessages);

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
