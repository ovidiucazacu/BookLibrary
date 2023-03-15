using Books.Data;
using Books.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Uid = Guid.NewGuid(),
                FirstName = "Mark",
                LastName = "Johnson",
                Code = 1,
                Classmate = "3A",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("2000-05-10"),
                Contact = "mark.johnson@email.com"
            },
            new Student
            {
                Uid = Guid.NewGuid(),
                FirstName = "Sam",
                LastName = "Jenkins",
                Code = 2,
                Classmate = "3A",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("2000-07-20"),
                Contact = "sam.jenkins@email.com"
            }
        };
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentAsync(Guid uid)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            return student;
        }


        public async Task<List<Student>> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return students;
        }

        public async Task<List<Student>> UpdateStudentAsync(Guid uid, Student request)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Code = request.Code;
            student.Classmate = request.Classmate;
            student.Gender = request.Gender;
            student.DateOfBirth = request.DateOfBirth;
            student.Contact = request.Contact;

            await _context.SaveChangesAsync();
            return students;
        }

        public async Task<List<Student>> DeleteStudentAsync(Guid uid)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return students;
        }
    }
}