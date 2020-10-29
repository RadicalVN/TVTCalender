using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class TVTDateTime
    {
        /// <summary>
        /// Trả về số ngày của tháng được truyền vào 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DayOfMonth(DateTime date)
        {
            switch(date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 2:
                    if ((date.Year % 4 == 0) || ((date.Year % 100 == 0) && (date.Year % 400 == 0))) return 29;
                    else return 28;

                default: return 30;

            }
        }

        /// <summary>
        /// Trả về số ngày của tháng trước của tháng được truyền vào
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DayOfPreviousMonth(DateTime date)
        {
            switch (date.Month - 1)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 0:// Tháng 12 của năm trước
                    return 31;

                case 2:
                    if ((date.Year % 4 == 0) || ((date.Year % 100 != 0) && (date.Year % 400 == 0))) return 28;
                    else return 29;

                default: return 30;

            }
        }
    }
}
