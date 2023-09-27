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

            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r=>r.Users).HasForeignKey(u => u.RoleId);  
        }
    }
}
