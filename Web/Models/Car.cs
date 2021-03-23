using System;

namespace Web.Models
{
    public class Car
    {
        public int Id { get; set; } 
        public string Brand { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Color { get; set; }
        public string BodyNumber { get; set; }
        public string Characteristics { get; set; }
        public double Price { get; set; }

        public int CarBodyId { get; set; }
        public CarBody CarBody { get; set; }
        
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        
        public int? Equipment1Id { get; set; }
        public Equipment Equipment1 { get; set; }
        
        public int? Equipment2Id { get; set; }
        public Equipment Equipment2 { get; set; }
        
        public int? Equipment3Id { get; set; }
        public Equipment Equipment3 { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}