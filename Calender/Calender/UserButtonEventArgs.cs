using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class UserButtonEventArgs : EventArgs
    {
        #region // Property - Các tham số truyền vào
        private int _I;
        public int I { get => _I; set => _I = value; }

        private int _J;
        public int J { get => _J; set => _J = value; }

        #endregion
    }
}
