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
            Button oldButton = new Button() {Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };

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

        }
    }
}
