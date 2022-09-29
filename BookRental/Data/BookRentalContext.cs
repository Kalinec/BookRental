using BookRental.Model;
using BookRental.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Data
{
    internal class BookRentalContext : DbContext
    {
        private const string _connectionString = "Server=KAROL-PC;Database=BookRentalDB;Trusted_Connection=True;";
        public DbSet<ReaderDto> Readers { get; set; }
        public DbSet<BookDTO> Books { get; set; }
        public DbSet<LoanDto> Loans { get; set; }
        public DbSet<RoleDto> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleDto>()
                .HasIndex(p => p.RoleName)
                .IsUnique();

            modelBuilder.Entity<ReaderDto>()
                .HasIndex(p => p.Pesel)
                .IsUnique();

            modelBuilder.Entity<RoleDto>()
                .HasData(
                new RoleDto() { Id = 1, RoleName = "lecturer" },
                new RoleDto() { Id = 2, RoleName = "employee" },
                new RoleDto() { Id = 3, RoleName = "student" });
        }
    }
}
