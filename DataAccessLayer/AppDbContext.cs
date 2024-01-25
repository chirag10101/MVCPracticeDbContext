using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext()
        //{

        //}
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ChiragKishorKapadiya\\Documents\\StdDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }
        public DbSet<Course> Courses { get; set; }
    }
}
