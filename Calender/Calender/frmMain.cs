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
        public FrmMain()
        {
            InitializeComponent();

            LoadMatrix();
        }

        void LoadMatrix()
        {
            // Khai báo button đầu tiên và dùng thuộc tính Location của nó để những button khác tham chiếu đến
            Button oldButton = new Button() {Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };

            for (int i = 0; i < Cons.weekOfFrame; i++)
            {
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
                }
                oldButton = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldButton.Location.Y + oldButton.Height + Cons.margin) };
            }
        }

        void AddDateToMatrix(DateTime date)
        {

        }
    }
}
