namespace DBatsiskaitymasLaura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new UniversityDbContext();
            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}