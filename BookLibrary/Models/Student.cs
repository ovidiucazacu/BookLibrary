using System;

namespace BookLibrary.Models
{
    public class Student
    {
        public Guid Uid { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public int Classmate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Contact { get; set; } = string.Empty;
    }
}