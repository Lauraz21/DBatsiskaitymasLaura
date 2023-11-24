using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class LectureMenu
    {
        private UniversityDbContext _context;

        public LectureMenu(UniversityDbContext context)
        {
            _context = context;
        }
        public void ShowMenu()
        {
            Console.WriteLine("1. Sukurti paskaita \n2. Prideti paskaita i departamenta");

            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    CreateLecture();
                    break;

                case '2':
                    ApplyLectureToDepartment();
                    break;
            }
            Console.Clear();
        }
        private void CreateLecture()
        {
            Console.WriteLine("Iveskite pavadinima: ");
            Lecture lecture = new Lecture();
            lecture.Name = Console.ReadLine();

            Console.WriteLine("Iveskite pradzios laika: ");
            lecture.Start = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite pabaigos laika: ");
            lecture.End = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite paskaitos koda: ");
            lecture.LectureCode = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite kreditus: ");
            lecture.Credits = int.Parse(Console.ReadLine());

            List<string> validationErrors = lecture.Validate();
            if (validationErrors.Count > 0)
            {
                Console.WriteLine("\nNeteisingi duomenys");
                foreach (string error in validationErrors)
                {
                    Console.WriteLine(error);
                }
                Console.ReadKey();
                return;
            }

            _context.Lectures.Add(lecture);
            _context.SaveChanges();
        }
        private void ApplyLectureToDepartment() 
        {
            Console.WriteLine("Iveskite departamento koda: ");
            string departmentCode = Console.ReadLine();
            Department department = _context.Departments.First(department => department.DepartmentCode == departmentCode);

            Console.WriteLine("Iveskite paskaitos koda: ");
            int lectureCode = int.Parse(Console.ReadLine());
            Lecture lectureToAdd = _context.Lectures.First(lecture => lecture.LectureCode == lectureCode);

            if (department.DepartmentLectures is null)
            {
                department.DepartmentLectures = new List<DepartmentLecture>();
            }
            department.DepartmentLectures.Add(new DepartmentLecture()
            { Lecture = lectureToAdd, Department = department });
            _context.SaveChanges();
        }
    }

}
