using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class DisplayMenu
    {

        private UniversityDbContext _context;
        public DisplayMenu(UniversityDbContext context)
        {
            _context = context;
        }

        public void ShowMenu()
        {

            Console.WriteLine("1. Atvaizduoti departamento studentus \n2. Atvaizduoti departamento paskaita \n3. Atvaizduoti paskaitas pagal studenta ");
            char choice = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (choice)
            {
                case '1':
                    DisplayDepartmentStudents();
                    break;

                case '2':
                    DisplayDepartmentLectures();
                    break;

                case '3':
                    DisplayLecturesByStudent();
                    break;
            }
            Console.Clear();
        }
        private void DisplayDepartmentStudents()
        {
            Console.WriteLine("Iveskite departamento koda: ");
            string departmentCode = Console.ReadLine();
            Department department = _context.Departments.First(department => department.DepartmentCode == departmentCode);

            foreach (Student student in department.Students)
            {
                Console.WriteLine($"Vardas: {student.Name} \nPavarde: {student.LastName} \nEl. pastas: {student.Email} \nKodas: {student.StudentCode}");
            }
        }
        private void DisplayDepartmentLectures()
        {
            Console.WriteLine("Iveskite departamento koda: ");
            string departmentCode2 = Console.ReadLine();
            List<DepartmentLecture> departmentLectures = _context.DepartmentLectures
                .Where(dl => dl.Department.DepartmentCode == departmentCode2).Include(dl => dl.Lecture).ToList();

            foreach (DepartmentLecture departmentLecture in departmentLectures)
            {
                Lecture lecture = departmentLecture.Lecture;
                Console.WriteLine($"Pavadinimas: {lecture.Name} \nPaskaitos laikas: {lecture.Start}h-{lecture.End}h \nPaskaitos kodas: {lecture.LectureCode} \nPaskaitos kreditai: {lecture.Credits}");
            }
        }
        private void DisplayLecturesByStudent()
        {
            Console.WriteLine("Iveskite studento koda: ");
            int studentCode = int.Parse(Console.ReadLine());
            List<StudentLecture> studentLectures = _context.StudentLectures
            .Where(sl => sl.Student.StudentCode == studentCode).Include(sl => sl.Lecture).ToList();

            foreach (StudentLecture studentLecture in studentLectures)
            {
                Lecture lecture = studentLecture.Lecture;
                Console.WriteLine($"Pavadinimas: {lecture.Name} \nPaskaitos laikas: {lecture.Start}h-{lecture.End}h \nPaskaitos kodas: {lecture.LectureCode} \nPaskaitos kreditai: {lecture.Credits}");
            }
        }
    }
}
