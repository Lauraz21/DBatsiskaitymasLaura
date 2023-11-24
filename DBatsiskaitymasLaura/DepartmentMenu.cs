using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class DepartmentMenu
    {
        private UniversityDbContext _context;
        public DepartmentMenu(UniversityDbContext context)
        {
            _context = context;
        }
        public void ShowMenu()
        {
            Console.WriteLine("Iveskite pavadinima: ");
            Department department = new Department();
            department.Name = Console.ReadLine();

            Console.WriteLine("Iveskite departamento koda: ");
            department.DepartmentCode = Console.ReadLine();

            List<string> validationErrors = department.Validate();
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
            _context.Departments.Add(department);
            _context.SaveChanges();

            Console.Clear();
        }
    }
}
