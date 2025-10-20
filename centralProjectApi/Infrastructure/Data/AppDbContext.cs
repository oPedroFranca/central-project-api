using centralProjectApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace centralProjectApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CardProject> CardProjects { get; set; }
        public DbSet<CardParticipant> CardParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CardProject>(entity =>
            {
                entity.ToTable("card_project");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Link).HasColumnName("link");
                entity.Property(e => e.GithubLink).HasColumnName("github_link");
                entity.Property(e => e.Technologies).HasColumnName("technologies");
                entity.Property(e => e.Images).HasColumnName("images");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CardParticipant>(entity =>
            {
                entity.ToTable("card_participant");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CardId).HasColumnName("card_project_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Role).HasColumnName("role");
                entity.Property(e => e.LinkedinUrl).HasColumnName("linkedin_url");
                entity.Property(e => e.GithubUrl).HasColumnName("github_url");

                entity.HasOne(e => e.Card)
                      .WithMany(cp => cp.Participants)
                      .HasForeignKey(e => e.CardId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
