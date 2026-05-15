using System.Collections.Generic;

namespace StudentAttendanceSystem
{
    public class AttendanceStatusApiResponse
    {
        public string status { get; set; }
        public List<AttendanceStatus> data { get; set; }
    }

    public class AttendanceStatus
    {
        public string value { get; set; }
        public string label { get; set; }
    }
}
