using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.TaskSchedule
{
    ublic class TaskNode
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public string DueDate { get; set; }
        public TaskNode Next { get; set; }

        public TaskNode(int id, string name, string priority, string dueDate)
        {
            TaskID = id;
            TaskName = name;
            Priority = priority;
            DueDate = dueDate;
            Next = null;
        }
    }
}
