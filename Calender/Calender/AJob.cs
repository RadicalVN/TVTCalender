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

        #region // Event
        private event EventHandler _SaveJob;
        /// <summary>
        /// Event lưu thông tin 1 công việc lại, lưu việc thêm hoặc sửa
        /// </summary>
        public event EventHandler SaveJob
        {
            add
            {
                _SaveJob += value;
            }
            remove
            {
                _SaveJob -= value;
            }
        }

        /// <summary>
        /// Event xóa 1 UserControl AJob và thông tin 1 công việc
        /// </summary>
        private event EventHandler _DeleteJob;
        public event EventHandler DeleteJob
        {
            add
            {
                _DeleteJob += value;
            }
            remove
            {
                _DeleteJob -= value;
            }
        }
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Lưu thông tin từ UserControl (AJob) về this (tức là đối tượng này) sau đó truyền vào jobject sender, và kích hoạt event
            Job.Job = txbJob.Text;

            DateTime Temp = new DateTime();
            Temp = Temp.AddYears(Job.Date.Year - 1);
            Temp = Temp.AddMonths(Job.Date.Month - 1);
            Temp = Temp.AddDays(Job.Date.Day - 1);
            Temp = Temp.AddHours((int)nmFromHour.Value);
            Temp = Temp.AddMinutes((int)nmFormMinute.Value);
            Job.FromTime = Temp;

            DateTime Temp1 = new DateTime();
            Temp1 = Temp1.AddYears(Job.Date.Year - 1);
            Temp1 = Temp1.AddMonths(Job.Date.Month - 1);
            Temp1 = Temp1.AddDays(Job.Date.Day - 1);
            Temp1 = Temp1.AddHours((int)nmToHour.Value);
            Temp1 = Temp1.AddMinutes((int)nmToMinute.Value);
            Job.ToTime = Temp1;

            Job.Status = PlanItem.JobStatus[cbStatus.SelectedIndex];

            // Nếu biến event đã được ủy thác
            _SaveJob?.Invoke(this, new EventArgs());
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _DeleteJob?.Invoke(this, new EventArgs());
        }

        private void CkbDone_CheckedChanged(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = ckbDone.Checked ? (int)EJobStatus.DONE : (int)EJobStatus.DOING;
        }

        private void CbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            ckbDone.Checked = ((sender as ComboBox).SelectedIndex == (int)EJobStatus.DONE) ? true : false;
        }
        #endregion

    }
}
