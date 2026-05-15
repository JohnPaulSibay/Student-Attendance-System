using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class LoginResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public UserData user { get; set; }
    }

    public class UserData
    {
        public int user_id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public int? student_id { get; set; }
        public int? teacher_id { get; set; }
    }
}
