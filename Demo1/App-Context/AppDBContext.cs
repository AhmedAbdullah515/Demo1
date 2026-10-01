using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.App_Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>().HasKey(a => a.CategoryId);
            modelBuilder.Entity<Category>().HasMany(a => a.Vehicles).WithOne(a => a.Category)
                .HasForeignKey(a => a.Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            //Sale
            modelBuilder.Entity<Sale>().HasKey(a => a.SaleId);
            modelBuilder.Entity<Sale>().HasOne(a => a.Customer).WithMany(a => a.Sales)
                .HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sale>().HasOne(a => a.Employee).WithMany(a => a.Sales)
                .HasForeignKey(a => a.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Sale>().Property(a => a.SalePrice).HasPrecision(12, 2);
            //vehicle
            modelBuilder.Entity<Vehicle>().HasKey(a => a.VehicleId);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.Sale).WithOne(a => a.Vehicle)
                .HasForeignKey<Sale>(a => a.SaleId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasIndex(a => a.VIN).IsUnique();
            modelBuilder.Entity<Vehicle>().Property(a => a.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Vehicle>().Property(a => a.Status).HasDefaultValue("Available");
            //Customer
            modelBuilder.Entity<Customer>().HasKey(a => a.CustomerId);
            modelBuilder.Entity<Customer>().HasOne(a => a.CustomerProfile).WithOne(a => a.Customer)
                .HasForeignKey<CustomerProfile>(a => a.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(a => a.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasKey(a => a.EmployeeId);
            modelBuilder.Entity<CustomerProfile>().HasKey(a => a.CustomerProfileId);
            //Data Seeding
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, Name = "Sedan", Description = "A sedan is a passenger car in a three-box configuration with separate compartments for engine, passenger, and cargo." },
                new Category { CategoryId = 2, Name = "SUV", Description = "A sport utility vehicle (SUV) is a versatile vehicle that combines elements of road-going passenger cars with features from off-road vehicles." },
                new Category { CategoryId = 3, Name = "Truck", Description = "A truck is a motor vehicle designed to transport cargo. Trucks vary greatly in size, power, and configuration." }
                );
            //vehicle
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    Color = "Blue",
                    Price = 25000,
                    Mileage1 = 15000,
                    VIN = "1HGCM82633A123456",
                    FuelType = "Gasoline",
                    Transmission = "Automatic",
                    Status = "Available",
                    Id = 2
                },
                new Vehicle
                {
                    VehicleId = 2,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2019,
                    Color = "Red",
                    Price = 20000,
                    Mileage1 = 20000,
                    VIN = "1HGCM82633A654321",
                    FuelType = "Gasoline",
                    Transmission = "Manual",
                    Status = "Available",
                    Id =1
                    
                },
                new Vehicle
                {
                    VehicleId = 3,
                    Make = "Ford",
                    Model = "F-150",
                    Year = 2021,
                    Color = "Black",
                    Price = 35000,
                    Mileage1 = 10000,
                    VIN = "1FTFW1E50MFA12345",
                    FuelType = "Diesel",
                    Transmission = "Automatic",
                    Status = "Available",
                    Id =2
                    
                }



                );

            //Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FullName = "Ahmed Hassan", Email = "ahmed.hassan@example.com", Phone = "1234567890", DriverLicenseNumber = "D1234567" },

                new Customer { CustomerId = 2, FullName = "Mona Adel", Email = "mona.adel@example.com", Phone = "0987654321", DriverLicenseNumber = "D7654321" },
                new Customer { CustomerId = 3, FullName = "Omar Khaled", Email = "omar.khaled@example.com", Phone = "01010000003", DriverLicenseNumber = "D9876543" }

                );
            //CustomerProfile
            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile { CustomerProfileId = 1, CustomerId = 1, Adress = "123 Main St, Cityville", DateOfBirth = new DateTime(1990, 5, 15) },
                new CustomerProfile { CustomerProfileId = 2, CustomerId = 2, Adress = "456 Elm St, Townsville", DateOfBirth = new DateTime(1985, 8, 20) },
                new CustomerProfile { CustomerProfileId = 3, CustomerId = 3, Adress = "789 Oak St, Villageville", DateOfBirth = new DateTime(1995, 12, 10) }
                );
            //Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FullName = "Mostafa Nabil", Position = "sales manager", Email = "mostafa@gmail.com", Phone = "01129344393", HireDate = new DateTime() },
                new Employee { EmployeeId = 2, FullName = "Ahmed Abdullah", Position = "Sales cosultat", Email = "Aya@gmail.com", Phone = "01029393399", HireDate = new DateTime() },
                new Employee { EmployeeId = 3, FullName = "Hassan Ali", Position = "sales cosulatle", Email = "Hassan@gmail.com", Phone = "01029393399", HireDate = new DateTime() }
                );
            //sales
            modelBuilder.Entity<Sale>().HasData(

                new Sale { SaleId = 1, SaleDate = new DateTime(2026, 1, 15), SalePrice = 25000, PaymentMethod = "Credit Card", Notes = "First sale", CustomerId = 1, EmployeeId = 1, VehicleId = 1 },
                new Sale { SaleId = 2, SaleDate = new DateTime(2026, 2, 20), SalePrice = 20000, PaymentMethod = "Cash", Notes = "Second sale", CustomerId = 2, EmployeeId = 2, VehicleId = 2 },
                new Sale { SaleId = 3, SaleDate = new DateTime(2026, 3, 10), SalePrice = 35000, PaymentMethod = "Bank Transfer", Notes = "Third sale", CustomerId = 3, EmployeeId = 3, VehicleId = 3 }

                );

        }
    }
}
