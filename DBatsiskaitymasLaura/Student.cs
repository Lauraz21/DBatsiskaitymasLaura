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
        
    }
}
