using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class Menu
    {
        private UniversityDbContext _context;
        private StudentMenu _studentMenu;
        private DepartmentMenu _departmentMenu;
        private LectureMenu _lectureMenu;
        private DisplayMenu _displayMenu;

        public Menu()
        {
            _context = new UniversityDbContext();
            _studentMenu = new StudentMenu(_context);
            _departmentMenu = new DepartmentMenu(_context);
            _lectureMenu = new LectureMenu(_context);
        }
        public void ShowMenu()
        {
            Console.WriteLine("STUDENTU INFORMACINE SISTEMA");
            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Sukurti departamenta" +
                        "\n2. Studentas \n3. Paskaita \n4. Atvaizdavimas ");

                    char choice = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (choice)
                    {
                        case '1':
                            _departmentMenu.ShowMenu();
                            break;
                        case '2':
                            _studentMenu.ShowMenu();
                            break;
                        case '3':
                            _lectureMenu.ShowMenu();
                            break;
                        case '4':
                            _displayMenu.ShowMenu();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ivyko klaida, meginkite dar karta");
                }
            }
        }
    }
}

