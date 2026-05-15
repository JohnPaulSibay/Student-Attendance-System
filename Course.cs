using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class Course
    {
        public int course_id { get; set; }
        public int? teacher_id { get; set; }
        public string course_code { get; set; }
        public string course_name { get; set; }
        public string lecturer { get; set; }
    }
}

