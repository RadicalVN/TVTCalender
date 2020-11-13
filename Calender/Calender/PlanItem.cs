using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    /// <summary>
    /// Trạng thái của 1 Job
    /// </summary>
    public enum EJobStatus
    {
        DONE,
        DOING,
        COMMING,
        MISSED
    }
    /// <summary>
    /// Lưu lại 1 công việc (Job)
    /// </summary>
    public class PlanItem
    {

        private DateTime _Date;
        /// <summary>
        /// Lưu thời gian (Ngày/Tháng/Năm) của công việc (Job)
        /// </summary>
        public DateTime Date { get => _Date; set => _Date = value; }

        private string _Job;
        /// <summary>
        /// Lưu nội dung công việc (Job)
        /// </summary>
        public string Job { get => _Job; set => _Job = value; }

        private DateTime _FromTime;
        /// <summary>
        /// Lưu thời gian bắt đầu của công việc (Job)
        /// </summary>
        public DateTime FromTime { get => _FromTime; set => _FromTime = value; }

        private DateTime _ToTime;
        /// <summary>
        /// Lưu thời gian kết thúc của công việc (Job)
        /// </summary>
        public DateTime ToTime { get => _ToTime; set => _ToTime = value; }

        private string _Status;
        /// <summary>
        /// Lưu trạng thái, tiến độ của công việc (Job)
        /// </summary>
        public string Status { get => _Status; set => _Status = value; }

        /// <summary>
        /// Lưu trạng thái, tiến độ của công việc (Job)
        /// </summary>
        public static List<string> JobStatus = new List<string>() {"DONE", "DOING", "COMMING", "MISSED"};
    }
}
