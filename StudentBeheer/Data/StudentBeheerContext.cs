using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentBeheer.Models;

namespace StudentBeheer.Data
{
    public class StudentBeheerContext : DbContext
    {
        public StudentBeheerContext (DbContextOptions<StudentBeheerContext> options)
            : base(options)
        {
        }

        public DbSet<StudentBeheer.Models.Student> Student { get; set; }

        public DbSet<StudentBeheer.Models.Module> Module { get; set; }

        public DbSet<StudentBeheer.Models.Inschrijvingen> Inschrijvingen { get; set; }

        
    }
}
