using Books.Models.Student;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-U8VIT8K\\SQLEXPRESS;Database=booklibrarydb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Student> Students { get; set; }
        public const string Schema = "student";

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