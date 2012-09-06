using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ToDoList.Model
{
    public class MemoryTaskList : ITaskListRepository
    {
        private  List<ToDoListItem> Tasks
        {
            get
            {
                if (HttpContext.Current.Session["Tasks"] == null)
                    Tasks = new List<ToDoListItem>();

                return HttpContext.Current.Session["Tasks"] as List<ToDoListItem>;
            }
            set
            {
                HttpContext.Current.Session["Tasks"] = value;
            }
        }

        #region ITaskListRepository Members

        public void AddTask(string description)
        {
            ToDoListItem newTask = new ToDoListItem() { ID = Guid.NewGuid(), Description = description, Created = DateTime.Now, IsComplete = false };

            Tasks.Add(newTask);
        }

        public void RemoveTask(Guid id)
        {
            var locatedTask = Tasks.FirstOrDefault(t => t.ID == id);
            if (locatedTask != null)
            {
                Tasks.Remove(locatedTask);
            }
        }

        public void MarkTaskComplete(Guid id)
        {
            var locatedTask = Tasks.FirstOrDefault(t => t.ID == id);
            if (locatedTask != null)
            {
                locatedTask.IsComplete = true;
            }
        }

        public ICollection<ToDoListItem> ListTasks()
        {
            return Tasks.OrderBy(t => t.IsComplete).ThenBy(t => t.Created).ToList();
        }

        #endregion
    }
}
