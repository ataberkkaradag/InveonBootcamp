using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(x=>x.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(x => x.Author).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(x => x.Genre).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(x => x.Language).IsRequired().HasMaxLength(100);  
            modelBuilder.Entity<Book>().Property(x => x.Publisher).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Book>().HasData(
           
            new Book
            {
                Id = 2,
                Title = "Dune",
                Author = "Frank Herbert",
                PublicationYear = 1965,
                ISBN = "978-0-441-17271-9",
                Genre = "Bilim Kurgu",
                Publisher = "Chilton Books",
                PageCount = 412,
                Language = "İngilizce",
                Summary="Lorem ipsum",
                AvailableCopies=6
            },
            new Book
            {
                Id = 3,
                Title = "Osmanlı İmparatorluğu",
                Author = "Halil İnalcık",
                PublicationYear = 1973,
                ISBN = "978-975-344-464-1",
                Genre = "Tarih",
                Publisher = "Yapı Kredi Yayınları",
                PageCount = 624,
                Language = "Türkçe",
                Summary = "Lorem ipsum",
                AvailableCopies = 6
            },
            new Book
            {
                Id = 4,
                Title = "1984",
                Author = "George Orwell",
                PublicationYear = 1949,
                ISBN = "978-0-452-28423-4",
                Genre = "Distopya",
                Publisher = "Secker & Warburg",
                PageCount = 328,
                Language = "İngilizce",
                Summary = "Lorem ipsum",
                AvailableCopies = 6
            });


            var roles = new List<AppRole>
            {
                new AppRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER" }
            };
            modelBuilder.Entity<AppRole>().HasData(roles);

            var hasher = new PasswordHasher<AppUser>();
            
            var adminUser = new AppUser
            {
                Id = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin1234*"),
                SecurityStamp = string.Empty
            };

            var normalUser = new AppUser
            {
                Id = new Guid("ac1d06b5-1c29-4222-9270-f3e9586a3e8f"), 
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User1234*"),
                SecurityStamp = string.Empty
            };


            modelBuilder.Entity<AppUser>().HasData(adminUser, normalUser);

            
            var userRoles = new List<IdentityUserRole<Guid>>
            {
                new IdentityUserRole<Guid> { UserId = adminUser.Id, RoleId = roles[0].Id }, 
                new IdentityUserRole<Guid> { UserId = normalUser.Id, RoleId = roles[1].Id }  
            };
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

        }

    }
}
