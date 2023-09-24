using Microsoft.EntityFrameworkCore;
using CadDesigner.Domain.Entitys;


namespace CadDesigner.Infrastructure.Persistence
{
    internal class DesignerDbContext : DbContext
    {
        public DesignerDbContext(DbContextOptions<DesignerDbContext> options) : base(options)
        {

        }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>().HasData(
           new Role
           {
               Id = 1,
               Name = "Administrator"
           },
           new Role
           {
               Id = 2,
               Name = "Designer"
           }
           );

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();
      
            modelBuilder.Entity<Designer>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Service>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
