using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class AttendanceRecord
    {
        public int attendance_id { get; set; }
        public int student_id { get; set; }
        public int? event_id { get; set; }
        public string student_number { get; set; }
        public string student_name { get; set; }
        public string event_name { get; set; }
        public string subject_code { get; set; }
        public string subject_name { get; set; }
        public string teacher_name { get; set; }
        public string attendance_date { get; set; }
        public string status { get; set; }
        public string time_in { get; set; }
        public string remarks { get; set; }
    }
}

