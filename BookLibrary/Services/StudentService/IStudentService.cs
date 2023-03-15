using Books.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace Books.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentAsync(Guid uid);
        Task<List<Student>> AddStudent([FromBody] Student student);
        Task<List<Student>> UpdateStudentAsync(Guid uid, Student request);
        Task<List<Student>> DeleteStudentAsync(Guid uid);
    }
}