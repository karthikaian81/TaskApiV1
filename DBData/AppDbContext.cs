using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.DBData
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TestTodoAppFormat>().Property(x => x.CreatedOn).ValueGeneratedOnAddOrUpdate();

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<TestTodoAppFormat> TestTodoAppFormats { get; set;}

        public DbSet<TodoUsersAppFormat> TodoUsersAppFormats { get; set;}

    }
}
