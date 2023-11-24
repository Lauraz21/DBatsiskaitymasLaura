using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class DepartmentLecture
    {
        public int DepartmentID { get; set; }
        public int LectureID { get; set; }
        public Department Department { get; set; }
        public Lecture Lecture { get; set;}
    }
}
