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

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (Name.Length <5)
            {
                errors.Add("Pavdinimas turi buti ne maziau kaip 5 simboliai");
            }
            if (Start < 7 || Start > 18 )
            {
                errors.Add("Pradzia turi buti tarp 7-18 val.");
            }
            if (End < 8 || End > 20)
            {
                errors.Add("Pabaiga turi buti tarp 8-20 val.");
            }
            return errors;
        }
    }
}
