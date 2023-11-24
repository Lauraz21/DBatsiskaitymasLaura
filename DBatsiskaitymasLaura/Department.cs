using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public string DepartmentCode { get; set; }
        public List<DepartmentLecture> DepartmentLectures { get; set; }

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Name.Length < 3 || Name.Length > 100)
            {
                errors.Add("Pavadinimas turi buti tarp 3 - 100 simboliu");
            }
            if (DepartmentCode.Length != 6)
            {
                errors.Add("Departamento kodas privalo buti 6 simboliai");
            }
            return errors;
        }
    }
}
