using System;

namespace Web.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; } 
        public string Phone { get; set; } 
        public string Passport { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsDone { get; set; }
        public bool IsPayment { get; set; }
        public double PrepaymentPercentage { get; set; }
        
        
        public int? CarId { get; set; }
        public Car Car { get; set; }
        
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}