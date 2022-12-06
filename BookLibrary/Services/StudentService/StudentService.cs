using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentAsync(Guid uid)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            return student;
        }

        public async Task<List<Student>> AddStudentAsync(Student request)
        {
            _context.Students.Add(request);
            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>?> UpdateStudentAsync(Guid uid, Student request)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            student.Name = request.Name;
            student.Code = request.Code;
            student.Classmate = request.Classmate;
            student.Gender = request.Gender;
            student.DateOfBirth = request.DateOfBirth;
            student.Contact = request.Contact;

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>?> DeleteStudentAsync(Guid uid)
        {
            var student = await _context.Students.FindAsync(uid);

            if (student is null)
                return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }
    }
}
