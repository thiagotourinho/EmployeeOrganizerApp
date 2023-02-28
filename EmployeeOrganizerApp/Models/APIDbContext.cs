using EmployeeOrganizerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.Metrics;

namespace StudentAPI.Models
{
    public class APIDbContext : DbContext   {

        public APIDbContext(DbContextOptions option) : base(option)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}
