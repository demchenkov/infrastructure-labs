using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web
{
    public static class DataSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(x => x.Car)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Sales Manager", Salary = 1000 },
                new Position { Id = 2, Name = "Finance Manager", Salary = 1500 },
                new Position { Id = 3, Name = "Customer Service Representative", Salary = 2000 },
                new Position { Id = 4, Name = "Car Detailer", Salary = 3000 },
                new Position { Id = 5, Name = "Lot Manager", Salary = 6000 }
            );
            
            
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1,  FullName = "George F Marks",     Age = 18, Gender = Gender.Male,   PositionId = 2 },
                new Employee { Id = 2,  FullName = "Robert J Shaw",      Age = 19, Gender = Gender.Male,   PositionId = 3 },
                new Employee { Id = 3,  FullName = "Sergio C Hunter",    Age = 20, Gender = Gender.Male,   PositionId = 2 },
                new Employee { Id = 4,  FullName = "Betty L Johnson",    Age = 21, Gender = Gender.Female, PositionId = 4 },
                new Employee { Id = 5,  FullName = "Tara T Fenn",        Age = 22, Gender = Gender.Female, PositionId = 1 },
                new Employee { Id = 6,  FullName = "Freda G Brooks",     Age = 23, Gender = Gender.None,   PositionId = 1 },
                new Employee { Id = 7,  FullName = "Brian R Atkinson",   Age = 24, Gender = Gender.None,   PositionId = 1 },
                new Employee { Id = 8,  FullName = "Kenneth J Goudreau", Age = 25, Gender = Gender.Male,   PositionId = 2 },
                new Employee { Id = 9,  FullName = "Kristina K Denis",   Age = 26, Gender = Gender.Female, PositionId = 3 },
                new Employee { Id = 10, FullName = "June D Hudson",      Age = 27, Gender = Gender.Female, PositionId = 5 }
            );
            
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "General Motors", Description = "General Motors (GM), one of the world's largest auto manufacturers, makes and sells cars and trucks worldwide under well-known brands such as Buick, Cadillac, Chevrolet, and GMC.", Country = "USA", Address = "185  West Side Avenue", EmployeeId = 1 },
                new Manufacturer { Id = 2, Name = "Toyota Motor Corp.", Description = "TOYOTA MOTOR CORPORATION is a Japan-based company engaged in the automobile business, finance business and other businesses. ", Country = "Japan", Address = "1607  Owen Lane", EmployeeId = 5 },
                new Manufacturer { Id = 3, Name = "Volkswagen Group", Description = "Volkswagen Group, also called Volkswagen AG, major German automobile manufacturer, founded by the German government in 1937 to mass-produce a low-priced “people's car.”", Country = "German", Address = "3853  Zappia Drive", EmployeeId = 7 },
                new Manufacturer { Id = 4, Name = "BMW Group", Description = "Bayerische Motoren Werke AG, commonly known as Bavarian Motor Works, BMW or BMW AG, is a German automobile, motorcycle and engine manufacturing company founded in 1916", Country = "German", Address = "2628  Sycamore Fork Road", EmployeeId = 2 },
                new Manufacturer { Id = 5, Name = "PSA Group", Description = "Formerly known as PSA Peugeot Citroën from 1991 to 2016), was a French multinational manufacturer of automobiles and motorcycles sold under the Peugeot, Citroën, DS,", Country = "France", Address = "3599  Thomas Street", EmployeeId = 6 }
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment {Id = 1, Name = "First Aid Kit", Price = 100},
                new Equipment {Id = 2, Name = "Tactical Flashlight", Price = 200},
                new Equipment {Id = 3, Name = "Multi-Tool", Price = 50},
                new Equipment {Id = 4, Name = "Car Hammer", Price = 150},
                new Equipment {Id = 5, Name = "Ice-scraper", Price = 99}
            );

            modelBuilder.Entity<CarBody>().HasData(
                new CarBody { Id = 1, Name = "Sedan" },
                new CarBody { Id = 2, Name = "Coupe" },
                new CarBody { Id = 3, Name = "Hatchback" },
                new CarBody { Id = 4, Name = "Limousine" },
                new CarBody { Id = 5, Name = "Minivan" }
            );
            
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1,  ManufacturerId = 1, EmployeeId = 1, ManufactureDate = RandomDateTime(), Price = 20000, CarBodyId = 1, BodyNumber = "5TFJX4GNXDX018902", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Aqua.ToString(), Brand = "Chevrolet",},
                new Car { Id = 2,  ManufacturerId = 2, EmployeeId = 2, ManufactureDate = RandomDateTime(), Price = 20500, CarBodyId = 2, BodyNumber = "JTHBE262962076696", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Firebrick.ToString(), Brand = "Toyota",},
                new Car { Id = 3,  ManufacturerId = 5, EmployeeId = 4, ManufactureDate = RandomDateTime(), Price = 50000, CarBodyId = 4, BodyNumber = "JTEZT14R168050778", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Gainsboro.ToString(), Brand = "Peugeot",},
                new Car { Id = 4,  ManufacturerId = 3, EmployeeId = 5, ManufactureDate = RandomDateTime(), Price = 26000, CarBodyId = 3, BodyNumber = "3LNHL2GC6CR898612", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Yellow.ToString(), Brand = "Volkswagen",},
                new Car { Id = 5,  ManufacturerId = 2, EmployeeId = 6, ManufactureDate = RandomDateTime(), Price = 20700, CarBodyId = 5, BodyNumber = "KNAGE123175119229", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Azure.ToString(), Brand = "Toyota",},
                new Car { Id = 6,  ManufacturerId = 5, EmployeeId = 2, ManufactureDate = RandomDateTime(), Price = 30000, CarBodyId = 4, BodyNumber = "1G1ZS518X6F146715", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.YellowGreen.ToString(), Brand = "Peugeot",},
                new Car { Id = 7,  ManufacturerId = 2, EmployeeId = 7, ManufactureDate = RandomDateTime(), Price = 25000, CarBodyId = 2, BodyNumber = "1ZVHT80N365193130", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Linen.ToString(), Brand = "Toyota",},
                new Car { Id = 8,  ManufacturerId = 4, EmployeeId = 8, ManufactureDate = RandomDateTime(), Price = 23000, CarBodyId = 4, BodyNumber = "2A8HR54PX8R129788", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Teal.ToString(), Brand = "BMW",},
                new Car { Id = 9,  ManufacturerId = 1, EmployeeId = 2, ManufactureDate = RandomDateTime(), Price = 80000, CarBodyId = 1, BodyNumber = "WMWZC3C50DWP16002", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.Cornsilk.ToString(), Brand = "Cadillac",},
                new Car { Id = 10, ManufacturerId = 3, EmployeeId = 9, ManufactureDate = RandomDateTime(), Price = 99000, CarBodyId = 5, BodyNumber = "1G11H5SA3DU187967", Equipment1Id = 1, Equipment2Id = 2, Equipment3Id = 3, Color = Color.PowderBlue.ToString(), Brand = "Volkswagen",}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.NewGuid(), Phone = "215-756-7457", Passport = "204-64-7000", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 2, EmployeeId = 5, IsDone = false, IsPayment = true, PrepaymentPercentage = 10, Name = "Jacob A Frazier", Address = "2981  Tipple Road", },
                new Customer { Id = Guid.NewGuid(), Phone = "509-305-4300", Passport = "532-38-6188", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 5, EmployeeId = 6, IsDone = false, IsPayment = false, PrepaymentPercentage = 12, Name = "Rebecca M McIntosh", Address = "3226  Goodwin Avenue", },
                new Customer { Id = Guid.NewGuid(), Phone = "580-977-7609", Passport = "287-90-1608", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 6, EmployeeId = 7, IsDone = true, IsPayment = true, PrepaymentPercentage = 14, Name = "George E Lindquist", Address = "3601  Dovetail Estates"},
                new Customer { Id = Guid.NewGuid(), Phone = "201-584-5301", Passport = "568-41-0182", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 8, EmployeeId = 8, IsDone = false, IsPayment = false, PrepaymentPercentage = 56, Name = "Joanne A Freeman", Address = "2670  Hillhaven Drive"},
                new Customer { Id = Guid.NewGuid(), Phone = "508-926-8765", Passport = "292-26-7557", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 5, EmployeeId = 2, IsDone = false, IsPayment = true, PrepaymentPercentage = 99, Name = "Tracy C Robinson", Address = "2994  Briarwood Road"},
                new Customer { Id = Guid.NewGuid(), Phone = "818-840-4421", Passport = "366-21-9992", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 4, EmployeeId = 5, IsDone = false, IsPayment = false, PrepaymentPercentage = 1, Name = "Tammy E Wolf", Address = "1887  Sigley Road"},
                new Customer { Id = Guid.NewGuid(), Phone = "405-733-5090", Passport = "366-21-9992", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 7, EmployeeId = 4, IsDone = true, IsPayment = true, PrepaymentPercentage = 22, Name = "Norman L Hernandez", Address = "535  Boundary Street"},
                new Customer { Id = Guid.NewGuid(), Phone = "301-236-7537", Passport = "450-39-0363", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 8, EmployeeId = 2, IsDone = false, IsPayment = false, PrepaymentPercentage = 54, Name = "Scott J Harris", Address = "585  Leisure Lane"},
                new Customer { Id = Guid.NewGuid(), Phone = "805-907-2039", Passport = "551-81-0381", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 1, EmployeeId = 1, IsDone = true, IsPayment = true, PrepaymentPercentage = 76, Name = "Jeremy M Sanson", Address = "4480  Roosevelt Street"},
                new Customer { Id = Guid.NewGuid(), Phone = "614-499-4827", Passport = "287-22-1837", OrderDate = RandomDateTime(), SaleDate = RandomDateTime(), CarId = 9, EmployeeId = 9, IsDone = false, IsPayment = false, PrepaymentPercentage = 100, Name = "Angela C Moreno", Address = "3504  Henery Street" }
            );
        }


        private static DateTime RandomDateTime()
        {
            var random = new Random();
            return DateTime.Now.AddYears(-random.Next(5));
        }
    }
}