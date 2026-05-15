using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class StudentApiResponse
    {
        public string status { get; set; }
        public List<Student> data { get; set; }
    }
}
