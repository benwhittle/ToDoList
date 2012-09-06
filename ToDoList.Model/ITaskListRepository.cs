using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    // Definition for the underlying datasource, allowing us to easily create and switch between different implementations e.g. memory or sql
    public interface ITaskListRepository
    {
        void AddTask(string description);
        void RemoveTask(Guid id);
        void MarkTaskComplete(Guid id);
        ICollection<ToDoListItem> ListTasks();
    }
}
