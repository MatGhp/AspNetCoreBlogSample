using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreBlogSample.Models.ViewModels;

namespace AspNetCoreBlogSample.Models.DB
{
    public partial class BlogSampleContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=BlogSample;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        //}

        public BlogSampleContext(DbContextOptions<BlogSampleContext> optionsBuilder)
: base(optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.PostId)
                    .HasName("IX_PostId");

                entity.Property(e => e.AuthorEmail).HasMaxLength(100);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_dbo.Comments_dbo.Posts_PostId");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.EditedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Post_ToTableUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<User> User { get; set; }
        public DbSet<AddPostViewModel> AddPostViewModel { get; set; }

        
    }
}