using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        //Constructor
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
            );
            //Add Seed Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "James",
                    LastName = "Williams",
                    Phone = "524-234-5443",
                    Email = "JamesWilliams@gmail.com",
                    CategoryId = 1,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Laura",
                    LastName = "Smith",
                    Phone = "524-122-3556",
                    Email = "Lsmith@gmail.com",
                    CategoryId = 2,
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}
