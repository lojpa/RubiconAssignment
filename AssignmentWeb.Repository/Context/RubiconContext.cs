using System;
using AssignmentWeb.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWeb.Repository.Context
{
    public class RubiconContext : DbContext
    {
        public RubiconContext(DbContextOptions<RubiconContext> options) : base(options)
        {
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "Title test",
                    Slug = "title-test",
                    Body = "Body test",
                    Description = "Description test",
                    CreatedAt = DateTime.UtcNow,
                },
                new Post
                {
                    PostId = 2,
                    Title = "Title test2",
                    Slug = "title-test2",
                    Body = "Body test2",
                    Description = "Description test2",
                    CreatedAt = DateTime.UtcNow
                },
                new Post
                {
                    PostId = 3,
                    Title = "Title test3",
                    Slug = "title-test3",
                    Body = "Body test3",
                    Description = "Description test3",
                    CreatedAt = DateTime.UtcNow
                },
                new Post
                {
                    PostId = 4,
                    Title = "Title test4",
                    Slug = "title-test4",
                    Body = "Body test4",
                    Description = "Description test4",
                    CreatedAt = DateTime.UtcNow
                }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { TagId = "tag1" },
                new Tag() { TagId = "tag2" },
                new Tag() { TagId = "tag3" },
                new Tag() { TagId = "tag4" }
            );

            modelBuilder.Entity<PostTag>().HasData(
                new PostTag()
                {
                    PostId = 1,
                    TagId = "tag1"
                },
                new PostTag()
                {
                    PostId = 2,
                    TagId = "tag2"
                },
                new PostTag()
                {
                    PostId = 3,
                    TagId = "tag3"
                },
                new PostTag()
                {
                    PostId = 4,
                    TagId = "tag4"
                },
                new PostTag()
                {
                    PostId = 1,
                    TagId = "tag4"
                },
                new PostTag()
                {
                    PostId = 2,
                    TagId = "tag3"
                }
            );
        }
    }
}
