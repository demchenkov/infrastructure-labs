namespace Web.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; } 
        public string Description { get; set; }
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}