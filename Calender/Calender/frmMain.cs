﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Calender
{
    public partial class FrmMain : Form
    {
        #region // Properties

        private List<List<UserButton>> matrix;
        public List<List<UserButton>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private List<string> dateOfWeek = new List<string>()
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        private PlanData _JobObj;
        /// <summary>
        /// Đối tượng công việc
        /// </summary>
        public PlanData JobObj { get => _JobObj; set => _JobObj = value; }

        private string filePath = "data.xml";

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            LoadMatrixButton();

            try
            {
                JobObj =  (DeserializeAllDataFromXML(filePath) as PlanData);
            }
            catch
            {
                MessageBox.Show("Lỗi load dữ liệu công việc từ file xml!");
                //SetDefaultJobData();
            } // Load data lập lịch lên

        }

        #region // Method of User define
        void LoadMatrixButton()
        {
            // Khai báo, cấp phát vùng nhớ cho Matrix (mảng 2 chiều kiểu List)
            Matrix = new List<List<UserButton>>();

            // Khai báo button đầu tiên (tham chiếu vị trí) và dùng thuộc tính Location của nó để những button khác tham chiếu đến
            UserButton oldButton = new UserButton() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };

            for (int i = 0; i < Cons.weekOfFrame; i++)
            {
                // Add 1 mảng 1 chiều kiểu List<Button> vào mảng
                Matrix.Add(new List<UserButton>());
                for (int j = 0; j < Cons.dayOfWeek; j++)
                {
                    UserButton btnMatrix = new UserButton()
                    {
                        Width = Cons.dateButtonWidth,
                        Height = Cons.dateButtonHeight,
                        Location = new Point(oldButton.Location.X + oldButton.Width + Cons.margin, oldButton.Location.Y)
                    };
                    btnMatrix.Click += BtnMatrix_Click;

                    pnlMatrix.Controls.Add(btnMatrix);

                    oldButton = btnMatrix;

                    // Add đối tượng btn (kiểu Button) vào mảng i
                    Matrix[i].Add(btnMatrix);
                }
                oldButton = new UserButton() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldButton.Location.Y + oldButton.Height + Cons.margin) };
            }

            ClearMatrixButton();
            AddDateToMatrix(dtpkDate.Value);
        } // Load MatrixButton lên Form (Lên Panel)
        
        void ClearMatrixButton()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    UserButton btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        } // Clear MatrixButton về mặc định

        void AddDateToMatrix(DateTime date)
        {
            // Tạo 1 đối tượng kiểu DateTime với ngày = 1 để xác định Button (vị trí) chứa ngày 1
            // Với Tháng/ Năm được lấy từ DateTimePicker truyền vào.
            // Từ đó triển khai thông tin ngày tháng.
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int dayOfMonth = UserDateTime.DayOfMonth(date); // Số ngày của tháng truyền vào từ datetimepicker
            int dayOfPreviousMonth = UserDateTime.DayOfMonth(date.AddMonths(-1)); // Số ngày của tháng trước đó

            // Cột hiển thị ngày 1 của tháng được chọn
            int indexColumn = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
            
            // Ngày đầu tiên của khung hiển thị (Matrix[0][0])
            int beginDay = dayOfPreviousMonth - (indexColumn - 1);

            // Ngày ToDay mặc định Ngày/THáng/Năm: 1/1/1
            DateTime ToDay = new DateTime();
            ToDay = ToDay.AddYears(date.Year - 1);      // => 1/1/(date.Year)
            if(beginDay == 1) 
            {
                ToDay = ToDay.AddMonths(date.Month - 1);// => 1/(date.Month)/(date.Year)
            }// Ngày 1 của tháng truyền vào (từ DateTimePicker) nằm đúng ở hàng đầu, cột đầu
            else 
            {
                ToDay = ToDay.AddMonths((date.Month - 1) - 1);    // => 1/(date.Month - 1)/(date.Year)
            }// Ngày 1 của tháng truyền vào (từ DateTimePicker) không nằm ở hàng đầu, cột đầu
            ToDay = ToDay.AddDays(beginDay - 1);        // => beginDay/(date.Month)/(date.Year)
            
            for (int i = 0; i < Cons.weekOfFrame; i++)
            {
                for (int j = 0; j < Cons.dayOfWeek; j++)
                {

                    UserButton btn = Matrix[i][j];

                    #region // V2 - Đoạn code mới được thay thế để test

                    if (ToDay.Month < date.Month) // Tháng trước
                    {
                        btn.Enabled = false;
                        btn.ForeColor = Color.Silver;
                        btn.Text = ToDay.Day.ToString();
                    }
                    else if(ToDay.Month == date.Month) // Tháng hiện tại
                    {
                        btn.Enabled = true;
                        btn.ForeColor = Color.Black;
                        if (ToDay.Day == 1)
                        {
                            btn.Text = ToDay.Day.ToString() + "/" + ToDay.Month.ToString();
                        }// Ngày đầu tháng, chuyển tháng
                        else
                        {
                            btn.Text = ToDay.Day.ToString();
                        }
                    }
                    else // Tháng sau
                    {
                        btn.Enabled = false;
                        btn.ForeColor = Color.Silver;
                        if (ToDay.Day == 1)
                        {
                            btn.Text = ToDay.Day.ToString() + "/" + ToDay.Month.ToString();
                        }// Ngày đầu tháng, chuyển tháng
                        else
                        {
                            btn.Text = ToDay.Day.ToString();
                        }
                    }
                    // Lưu lại thông tin (vị trí và date) của button 
                    btn.SaveDate(ToDay, i, j);

                    if (UserDateTime.IsEqualDay(ToDay, date))
                        btn.BackColor = Color.SkyBlue;
                    if (UserDateTime.IsEqualDay(ToDay, DateTime.Now))
                        btn.BackColor = Color.Blue;

                    // Tăng date lên 1 ngày
                    ToDay = ToDay.AddDays(1);

                    #endregion

                    #region // V1 - Tạm thời thay bằng code khác để test (bên trên)
                    /* Tạm thời test code khác
                    if (((i == 0) && (dateS > dayOfPreviousMonth)) || ((i != 0) && (dateS > dayOfMonth)))
                    {
                        dateS = 1;
                    }

                    if ((i == 0 && dateS > 7) || (i > 3 && dateS < 15))
                    {
                        btn.ForeColor = Color.Silver;
                    }
                    else
                    {
                        btn.ForeColor = Color.Black;

                        // Ngày được chọn trên dtpk thì màu Aqua
                        if (dateS == date.Day)
                        {
                            btn.BackColor = Color.SkyBlue;
                        }

                        // Ngày được chọn bằng ngày hiện tại thì màu blue
                        if ((DateTime.Now.Month == date.Month) && (DateTime.Now.Day == dateS))
                        {
                            btn.BackColor = Color.Aqua;
                        }
                    }

                    btn.Text = dateS.ToString();
                    
                    dateS++;
                    */
                    #endregion
                }
            }
        } // Add ngày vào Button trong Matrix

        private void SerializeAllDataToXML(object data, string filePath)
        {
            // Khai một đối tượng để tạo kết nối ứng dụng đến data, đồng thời cấu hình:
            // Đường dẫn data = filePath, 
            // Chế độ mở file: Mở file, làm rỗng file
            // Chế độ truy cập file: Mở file để ghi data vào,
            // Chế độ share data: không cho phép tiến trình khác truy cập (đọc/ghi/delete) nếu tiến trình hiện tại đang truy cập
            FileStream fs = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
            
            // Khai báo một đối tượng để Serialize (ghi và lưu) data (PlanData) xuống bộ nhớ
            // Chỉ định lưu (serialize) thành file XML
            // Serialize theo cấu trúc dữ liệu nào (hiện tại là kiểu dữ liệu PlanData)
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));
            
            // Thực hiện mở lưu data xuống
            sr.Serialize(fs, data);

            // Đóng kết nối
            fs.Close();
        } // Kết nối và lưu data xuống

        private object DeserializeAllDataFromXML(string filePath)
        {
            // Khai một đối tượng để tạo kết nối ứng dụng đến data, đồng thời cấu hình:
            // Đường dẫn data = filePath, 
            // Chế độ mở file: Mở file, nếu file không tồn tại thì tạo file mới
            // Chế độ truy cập file: Mở file để đọc (load) data lên
            // Chế độ share data: không cho phép tiến trình khác truy cập (đọc/ghi/delete) nếu tiến trình hiện tại đang truy cập
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {

                XmlSerializer sr = new XmlSerializer(typeof(PlanData));
                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch
            {
                fs.Close();
                throw new NotImplementedException();
            }
        } // Kết nối và load data lên

        private void SetDefaultJobData()
        {
            // Khởi tạo, cấp phát đối tượng
            JobObj = new PlanData();

            // Khai báo và khởi tạo 1 job mặc định
            PlanItem jobDefault = new PlanItem()
            {
                Date = DateTime.Now,
                Job = "Công việc mặc định, hãy chỉnh sửa",
                FromTime = DateTime.Now,
                ToTime = DateTime.Now,
                Status = PlanItem.JobStatus[(int)EJobStatus.DOING]
            };

            // Khai báo và khởi tạo 1 job mặc định
            PlanItem jobDefault2 = new PlanItem()
            {
                Date = DateTime.Now,
                Job = "Công việc thứ 2",
                FromTime = DateTime.Now,
                ToTime = DateTime.Now,
                Status = PlanItem.JobStatus[(int)EJobStatus.MISSED]
            };

            // Thêm jobDefault vào JobData (Danh sách công việc - data)
            JobObj.JobData = new List<PlanItem>() {jobDefault, jobDefault2};
        }// Thêm 1 công việc mặc định
        #endregion

        #region // Method of handling the Event
        private void DtpkDate_ValueChanged(object sender, EventArgs e)
        {
            ClearMatrixButton();
            AddDateToMatrix((sender as DateTimePicker).Value);
        }

        private void BtnPrivious_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void BtnMatrix_Click(object sender, EventArgs e)
        {
            UserButton btn = sender as UserButton;
            DateTime date = new DateTime(btn.Year, btn.Month, btn.Day);
            dtpkDate.Value = date;

            frmDailyPlan daily = new frmDailyPlan(date, JobObj);
            daily.ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeAllDataToXML(JobObj, filePath);
        }
        #endregion
    }
}