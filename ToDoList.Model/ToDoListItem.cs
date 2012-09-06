using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    public class ToDoListItem
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
    }
}
