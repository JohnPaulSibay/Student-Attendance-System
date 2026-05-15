using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class CourseApiResponse
    {
        public string status { get; set; }
        public List<Course> data { get; set; }
    }
}
