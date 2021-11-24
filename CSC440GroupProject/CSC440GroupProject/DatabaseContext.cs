using CSC440GroupProject.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject
{
    class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                connectionString: @"server=localhost;database=csc440;uid=root;password=;",
                mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(s => new { s.Prefix, s.Number, s.Year, s.Semester });
            modelBuilder.Entity<Student>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Grade>().HasKey(s => new { s.StudentId, s.CoursePrefix, s.CourseNum, s.Year, s.Semester });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
