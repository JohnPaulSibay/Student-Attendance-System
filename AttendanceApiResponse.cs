using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    public class AttendanceApiResponse
    {
        public string status { get; set; }
        public List<AttendanceRecord> data { get; set; }
    }
}
