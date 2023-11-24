using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public int StudentCode { get; set; }
        public string Name { get;set;}
        public string LastName { get;set;}
        public string Email { get;set;}
        public List<StudentLecture> StudentLectures { get; set; }   

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Name.Length < 2 || Name.Length > 50)
            {
                errors.Add("Vardas turi buti tarp 2 - 50 simboliu");
            }
            if (LastName.Length < 2 || LastName.Length > 50)
            {
                errors.Add("Pavarde turi buti tarp 2 - 50 simboliu");
            }
            if (!Email.Contains("@"))
            {
                errors.Add("El. pastas neteisingas");
            }
            if (StudentCode.ToString().Length != 8)
            {
                errors.Add("Studento kodas privalo buti 8 simboliai");
            }
            return errors;
        }
    }
}
