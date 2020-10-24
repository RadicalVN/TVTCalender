using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class Cons
    {
        /// <summary>
        /// dayOfWeek là số ngày trong 1 tuần
        /// </summary>
        public static int dayOfWeek = 7;

        /// <summary>
        /// Số tuần trong 1 khung lịch từng tháng.
        /// = (31 + 6)/7 làm tròn lên.
        /// </summary>
        public static int weekOfFrame = 6;

        public static int dateButtonWidth = 75;

        public static int dateButtonHeight = 40;

        public static int margin = 6;
    }
}
