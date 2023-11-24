using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class StudentLecture
    {
        public int StudentID { get; set; }
        public int LectureID { get; set; }
        public Student Student{ get; set; }
        public Lecture Lecture { get; set; }
    }
}
