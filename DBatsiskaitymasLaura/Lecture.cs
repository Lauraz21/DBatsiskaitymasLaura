using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBatsiskaitymasLaura
{
    public class Lecture
    {
        [Key]
       public int ID { get; set; }
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int LectureCode { get; set; }
        public int Credits { get; set; }

    }
}
