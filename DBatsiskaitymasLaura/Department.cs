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
    }
}
