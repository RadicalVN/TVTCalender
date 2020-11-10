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

    public partial class FrmMain : Form
    {

        #region Properties

        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private List<string> dateOfWeek = new List<string>()
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };
        #endregion

        public FrmMain()
        {
            InitializeComponent();
            LoadMatrixButton();
        }

        void LoadMatrixButton()
        {
            // Khai báo, cấp phát vùng nhớ cho Matrix (mảng 2 chiều kiểu List)
            Matrix = new List<List<Button>>();

            // Khai báo button đầu tiên và dùng thuộc tính Location của nó để những button khác tham chiếu đến
            Button oldButton = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };

            for (int i = 0; i < Cons.weekOfFrame; i++)
            {
                // Add 1 mảng 1 chiều kiểu List<Button> vào mảng
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.dayOfWeek; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.dateButtonWidth,
                        Height = Cons.dateButtonHeight,
                        Location = new Point(oldButton.Location.X + oldButton.Width + Cons.margin, oldButton.Location.Y)
                    };

                    pnlMatrix.Controls.Add(btn);

                    oldButton = btn;

                    // Add đối tượng btn (kiểu Button) vào mảng i
                    Matrix[i].Add(btn);
                }
                oldButton = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldButton.Location.Y + oldButton.Height + Cons.margin) };
            }

            ClearMatrixButton();
            AddDateToMatrix(dtpkDate.Value);
        }

        void ClearMatrixButton()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        }

        void AddDateToMatrix(DateTime date)
        {
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            int dayOfMonth = TVTDateTime.DayOfMonth(date); // Số ngày của tháng truyền vào từ datetimepicker
            int dayOfPreviousMonth = TVTDateTime.DayOfPreviousMonth(date); // Số ngày của tháng trước đó

            // Cột hiển thị ngày 1 của tháng được chọn
            int indexColumn = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());

            //int offsetDate = 1;
            int dateS = dayOfPreviousMonth - (indexColumn - 1);

            for (int i = 0; i < Cons.weekOfFrame; i++)
            {
                for (int j = 0; j < Cons.dayOfWeek; j++)
                {
                    Button btn = Matrix[i][j];
                    //EventArgs e = new EventArgs(int i, j);
                    // Ủy thác event cho từng button trong matrix
                    btn.Click += Btn_Click;
                    

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
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            ClearMatrixButton();
            AddDateToMatrix((sender as DateTimePicker).Value);
        }

        private void btnPrivious_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }
    }
}
