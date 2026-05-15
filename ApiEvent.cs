using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class ApiEvent
    {
        public int event_id { get; set; }
        public int course_id { get; set; }
        public int? teacher_id { get; set; }
        public string event_name { get; set; }
        public string course_code { get; set; }
        public string course_name { get; set; }
        public string room { get; set; }
        public string event_date { get; set; }
    }
}


