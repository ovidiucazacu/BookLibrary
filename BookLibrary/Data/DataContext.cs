using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookLibrary.Data
{
    public class DataContext : DbContext
    {
        public const string Schema = "student";

        public DbSet<Student> Students { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-G2RMSUJ\\SQLExpress;Database=booklibrarydb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Students
            var tblStudent = builder.Entity<Student>().ToTable("Students", Schema);

            tblStudent.HasKey(x => x.Uid);
            tblStudent.Property(x => x.Uid).ValueGeneratedOnAdd();
            tblStudent.Property(x => x.DateOfBirth).HasColumnType("date");
        }
    }
}
