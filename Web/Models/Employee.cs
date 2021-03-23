namespace Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}