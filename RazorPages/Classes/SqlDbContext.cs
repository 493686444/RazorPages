using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class SqlDbContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { set; get; }
        public DbSet<Message> Messages { set; get; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDatabase;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connstr)
#if DEBUG
                .EnableSensitiveDataLogging(true)
                .LogTo
                   (
                       (id, level) => level == LogLevel.Error,            //过滤条件
                        log => Console.WriteLine(log)   //如何记录log
                    );
#endif
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
