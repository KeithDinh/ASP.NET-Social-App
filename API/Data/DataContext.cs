using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DataContext: IdentityDbContext<
                                AppUser, AppRole, int, 
                                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
                                IdentityRoleClaim<int>, IdentityUserToken<int>
                                >
    {
        public DataContext(DbContextOptions options) : base(options)
        {}
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User and Role: many to many
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // form the primary key for this table
            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.LikedUserId});
            
            // For SQL Server, required adding DeleteBehavior.NoAction to prevent migration error
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser) 
                .WithMany(l => l.LikedUsers) // source user can like many users
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade); // delete the user = delete the related entity
                
            // the other side of the relationship
            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers) // liked user can have many likes
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Cascade); // delete the user will delete the like related rows in the UserLike

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict); // delete the user won't delete the messages

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict); // delete the user won't delete the messages
        }
    }
}