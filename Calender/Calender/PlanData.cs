using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    [Serializable] // Attribute mô tả việc tạo metadata để lưu data
    public class PlanData
    {
        private List<PlanItem> _JobData;
        /// <summary>
        /// Lưu công việc (Property)
        /// </summary>
        public List<PlanItem> JobData { get => _JobData; set => _JobData = value; }
    }
}
