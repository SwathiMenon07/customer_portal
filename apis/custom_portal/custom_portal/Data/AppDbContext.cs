using custom_portal.models;
using custom_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace custom_portal.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        { }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
       // {
           // modelBuilder.Entity<User>().ToTable("portal_userinfo");
        //}

    public DbSet<User> portal_userinfo { get; set; }
       
}

}
