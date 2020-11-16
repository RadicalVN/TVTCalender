using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class frmDailyPlan : Form
    {
        #region // Property of frmDailyPlan
        private DateTime _Date;
        /// <summary>
        /// Nggày cần xử lý
        /// </summary>
        public DateTime Date { get => _Date; set => _Date = value; }

        private PlanData _JobDataByDate;
        /// <summary>
        /// Dữ liệu về công việc của 1 ngày
        /// </summary>
        public PlanData JobDataByDate { get => _JobDataByDate; set => _JobDataByDate = value; }
        /// <summary>
        /// Khai báo 1 đối tượng kiểu FlowLayoutPanel để hỗ trợ việc chứa và thêm control dễ quản lý
        /// </summary>
        public FlowLayoutPanel fpnlJobs = new FlowLayoutPanel();
        #endregion

        /// <summary>
        /// Hàm dựng constructor: truyền vào ngày để lọc lấy job của ngày đó (từ UserButton được nhấn),
        /// Và truyền vào danh sách công việc (jobData)
        /// </summary>
        /// <param name="date"></param>
        /// <param name="jobData"></param>
        public frmDailyPlan(DateTime date, PlanData jobData)
        {
            // Hàm khởi tạo, vẽ form (frmDailyPlan)
            InitializeComponent();

            // Copy dữ liệu truyền vào sau khi khai báo, cấp phát và khởi tạo đối tượng.
            this.Date = date;
            this.JobDataByDate = jobData;
            // Set thuộc tính cho fpnlJobs
            fpnlJobs.Height = pnlJob.Height;
            fpnlJobs.Width = pnlJob.Width;
            fpnlJobs.AutoScroll = true;

            // Add fpnlJobs vào pnlJob
            pnlJob.Controls.Add(fpnlJobs);

            // Gán giá trị của DateTimePicker (dtpkDay) cho giá trị ngày (date) truyền vào từ button được nhấn
            dtpkDate.Value = Date;

        }// Hàm main của DailyPlan


        #region // Mothod 
        /// <summary>
        /// Thêm dữ liệu các việc của ngày (date) lên form
        /// </summary>
        /// <param name="date"></param>
        void AddJobsByDate(DateTime date)
        {
            // Xóa, reset fpnlJobs
            fpnlJobs.Controls.Clear();

            if(JobDataByDate != null && JobDataByDate.JobData != null)
            {
                // Tạo 1 đối tượng: danh sách công việc, và lấy những công việc theo ngày được chỉ định
                List<PlanItem> todayJob = GetJobByDate(date);

                // Add từng công việc vào fpnlJobs
                for (int i = 0; i < todayJob.Count; i++)
                {
                    // Add 1 công việc vào fpnlJobs
                    AddJob(todayJob[i]);
                }
            }
        }

        /// <summary>
        /// Trích xuất lấy những công việc theo ngày được chỉ định
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<PlanItem>  GetJobByDate(DateTime date)
        {
            // Tạo 1 đối tượng: danh sách công việc
            List<PlanItem> resultJobsByDate;

            // Trích xuất lấy danh sách những job phù hợp điều kiện ngày/tháng/năm truyền vào
            resultJobsByDate = JobDataByDate.JobData.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
            
            // return danh sách những công việc phù hợp
            return resultJobsByDate;
        }

        /// <summary>
        /// Thêm 1 UserControl (AJob) kèm thông tin công việc phù hợp vào fpnlJobs 
        /// </summary>
        /// <param name="ajob"></param>
        void AddJob(PlanItem ajob)
        {
            // Tạo 1 đối tượng kiểu UserControl (AJob) để lưu 1 thông tin 1 công việc
            AJob aJob = new AJob(ajob);

            // Ủy thác sự kiện Lưu và Xóa Job (Usercontrol tương ứng)
            aJob.SaveJob += AJob_SaveJob;
            aJob.DeleteJob += AJob_DeleteJob;

            fpnlJobs.Controls.Add(aJob);
        }
        #endregion

        #region // Method of handling the Event
        private void DtpkDate_ValueChanged(object sender, EventArgs e)
        {
            // Set lại ngày theo DateTimePicker
            //Date = (sender as DateTimePicker).Value;
            // Thêm dữ liệu công việc của ngày (Date) lên form
            AddJobsByDate((sender as DateTimePicker).Value);
        }

        private void BtnPrevieusDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void BtnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void MnsiAddJob_Click(object sender, EventArgs e)
        {
            PlanItem newItem = new PlanItem();
            newItem.Date = dtpkDate.Value;

            AJob newJob = new AJob(newItem);
            newJob.DeleteJob += NewJob_DeleteJob;
            fpnlJobs.Controls.Add(newJob);
            JobDataByDate.JobData.Add(newItem);
        }

        private void NewJob_DeleteJob(object sender, EventArgs e)
        {
            // UserControl cần xóa
            AJob JobNeedDelete = sender as AJob;

            // Dữ liệu công việc trong Item cần xóa
            PlanItem JobDataNeedDelete = JobNeedDelete.Job;

            // Xóa Usercontrol (AJob) ra khỏi FlowLayoutPanel (fpnlJobs)
            fpnlJobs.Controls.Remove(JobNeedDelete);

            // Xóa Công việc (Job = DataItem) khỏi dữ liệu
            JobDataByDate.JobData.Remove(JobDataNeedDelete);

            //AddJobsByDate(dtpkDate.Value);
        }

        private void MnsiToDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void AJob_DeleteJob(object sender, EventArgs e)
        {
            // UserControl cần xóa
            AJob JobNeedDelete = sender as AJob;

            // Dữ liệu công việc trong Item cần xóa
            PlanItem JobDataNeedDelete = JobNeedDelete.Job;

            // Xóa Usercontrol (AJob) ra khỏi FlowLayoutPanel (fpnlJobs)
            fpnlJobs.Controls.Remove(JobNeedDelete);

            // Xóa Công việc (Job = DataItem) khỏi dữ liệu
            JobDataByDate.JobData.Remove(JobDataNeedDelete);
            
            //AddJobsByDate(dtpkDate.Value);
        }

        private void AJob_SaveJob(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
