using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class Student
    {
        public int student_id { get; set; }
        public string student_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string course_code { get; set; }
        public string section_name { get; set; }
        public string year_level { get; set; }
        public string email { get; set; }
        public string contact_number { get; set; }
        public string status { get; set; }

        public string FullName
        {
            get { return first_name + " " + last_name; }
        }
    }
}
