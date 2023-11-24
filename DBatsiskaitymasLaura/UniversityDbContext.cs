using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<DepartmentLecture> DepartmentLectures { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=University;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepartmentLecture>()
                .HasKey(dl => new {dl.DepartmentID, dl.LectureID });

            modelBuilder.Entity<DepartmentLecture>()
                .HasOne(dl => dl.Department)
                .WithMany(d => d.DepartmentLectures)
                .HasForeignKey(dl => dl.DepartmentID);


            modelBuilder.Entity<StudentLecture>()
              .HasKey(sl => new {sl.StudentID, sl.LectureID });

            modelBuilder.Entity<StudentLecture>()
                .HasOne(sl => sl.Student)
                .WithMany(s => s.StudentLectures)
                .HasForeignKey(sl => sl.StudentID);
        }
    }

}
