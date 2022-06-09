using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Contexts
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts
        {
            get { return Set<Contact>(); }
        }

        public ContactDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .ToTable("Contact");

            modelBuilder.Entity<Contact>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}