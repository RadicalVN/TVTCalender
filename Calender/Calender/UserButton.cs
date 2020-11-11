using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    public partial class UserButton : System.Windows.Forms.Button // Kế thừa từ button cũ của VS
    {
        #region // Property
        /// <summary>
        /// Lưu vị trí hàng ở trong matrix button
        /// </summary>
        private int _IndexRow;
        public int IndexRow { get => _IndexRow; set => _IndexRow = value; }

        /// <summary>
        /// Lưu vị trí cột ở trong matrix button
        /// </summary>
        private int _IndexColumn;
        public int IndexColumn { get => _IndexColumn; set => _IndexColumn = value; }

        /// <summary>
        /// Lưu thông tin Ngày
        /// </summary>
        private int _Day;
        public int Day { get => _Day; set => _Day = value; }

        /// <summary>
        /// Lưu thông tin Tháng
        /// </summary>
        private int _Month;
        public int Month { get => _Month; set => _Month = value; }

        /// <summary>
        /// Lưu thông tin Năm
        /// </summary>
        private int _Year;
        public int Year { get => _Year; set => _Year = value; }

        #endregion

        #region // User define Method
        public void SaveDate(DateTime date, int indexRow, int indexColumn)
        {
            IndexRow = indexRow;
            IndexColumn = indexColumn;
            Day = date.Day;
            Month = date.Month;
            Year = date.Year;
        }
        #endregion

        public UserButton()
        {
            InitializeComponent();
        }

        public UserButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
