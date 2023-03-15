namespace Books.Models.Student
{
    public class Student
    {
        public Guid Uid { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Code { get; set; }
        public string Classmate { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Contact { get; set; } = string.Empty;
    }
}