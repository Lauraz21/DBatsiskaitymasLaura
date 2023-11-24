using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class StudentMenu
    {
        private UniversityDbContext _context;
        public StudentMenu(UniversityDbContext context) 
        {
            _context = context;
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Sukurti studenta \n2. Priskirti departamenta \n3. Priskirti paskaita \nq. grizti");

                char choice = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (choice)
                {
                    case '1':
                        CreateStudent();
                        break;

                    case '2':
                        ApplyDepartment();
                        break;

                    case '3':
                        AddLecture();
                        break;

                    case 'q':
                        return;
                }
                Console.Clear();
            }
        }
        private void CreateStudent()
        {
            Console.WriteLine("Iveskite varda: ");
            Student student = new Student();
            student.Name = Console.ReadLine();

            Console.WriteLine("Iveskite pavarde: ");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Iveskite el. pasta: ");
            student.Email = Console.ReadLine();

            Console.WriteLine("Iveskite studento koda: ");
            student.StudentCode = int.Parse(Console.ReadLine());

            List<string> validationErrors = student.Validate();
            if (validationErrors.Count > 0)
            {
                Console.WriteLine("Neteisingi duomenys"); 
                foreach(string error in validationErrors)
                {
                    Console.WriteLine(error);
                }
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Iveskite departamento koda: ");
            string departmentCode = Console.ReadLine();
            Department department = _context.Departments.First(department => department.DepartmentCode == departmentCode);

            if (department.Students is null)
            {
                department.Students = new List<Student>();
            }

            department.Students.Add(student);
            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine("\nStudentas sukurtas");
            Console.ReadKey();
        }

        private void ApplyDepartment()
        {
            Console.WriteLine("Iveskite studento koda: ");
            int studentCode = int.Parse(Console.ReadLine());
            Student student = _context.Students.First(student => student.StudentCode == studentCode);

            Console.WriteLine("Iveskite departamento koda: ");
            string departmentCode = Console.ReadLine();
            Department department = _context.Departments.First(department => department.DepartmentCode == departmentCode);

            if (department.Students is null)
            {
                department.Students = new List<Student>();
            }
            department.Students.Add(student);
            _context.SaveChanges();
        }
        private void AddLecture()
        {
            Console.WriteLine("Iveskite studento koda: ");
            int studentCode = int.Parse(Console.ReadLine());
            Student student = _context.Students.First(student => student.StudentCode == studentCode);

            Console.WriteLine("Iveskite paskaitos koda: ");
            int lectureCode = int.Parse(Console.ReadLine());
            Lecture lectureToAdd = _context.Lectures.First(lecture => lecture.LectureCode == lectureCode);

            if (student.StudentLectures is null)
            {
                student.StudentLectures = new List<StudentLecture>();
            }
            student.StudentLectures.Add(new StudentLecture() 
            { Lecture = lectureToAdd, Student = student });
            _context.SaveChanges();
        }
    }
}
