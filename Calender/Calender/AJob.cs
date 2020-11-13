using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class AJob : UserControl
    {
        #region // Property
        
        private PlanItem _Job;
        // Một công việc
        public PlanItem Job { get => _Job; set => _Job = value; }
        
        #endregion
        /// <summary>
        /// Hàm main của class AJob
        /// </summary>
        /// <param name="job"></param>
        public AJob(PlanItem job)
        {
            InitializeComponent();
            this.Job = job;
            // Đưa list trạng thái vào combobox
            cbStatus.DataSource = PlanItem.JobStatus;
            AddInfoToAJob();
        }

        #region // Method

        // Thêm thông tin về 1 công việc vào 1 control AJob
        void AddInfoToAJob()
        {
            // CheckBox sẽ được check nếu thỏa:
            // Trạng thái công việc (chỉ số của công việc đó trong danh sách (list JobStatus)) = (int)Enum.DONE (EJobStatus)
            ckbDone.Checked = (PlanItem.JobStatus.IndexOf(Job.Status) == (int)EJobStatus.DONE) ? true: false;

            txbJob.Text = Job.Job;

            nmFromHour.Value = Job.FromTime.Hour;
            nmFormMinute.Value = Job.FromTime.Minute;

            nmToHour.Value = Job.ToTime.Hour;
            nmToMinute.Value = Job.ToTime.Minute;

            cbStatus.SelectedIndex = PlanItem.JobStatus.IndexOf(Job.Status);
        }
        #endregion

        #region // Method of handling the Event
        #endregion
    }
}
