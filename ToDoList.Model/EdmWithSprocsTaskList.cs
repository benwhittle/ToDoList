using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    public class EdmWithSprocsTaskList : ITaskListRepository
    {
        private ToDoListEntities entities = new ToDoListEntities();

        public void AddTask(string description)
        {
            entities.AddTask(description);
        }

        public void RemoveTask(Guid id)
        {
            entities.DeleteTask(id);
        }

        public void MarkTaskComplete(Guid id)
        {
            entities.MarkTaskAsComplete(id);
        }

        public ICollection<ToDoListItem> ListTasks()
        {
            var v = from a in entities.GetTasks()
                   select new ToDoListItem() { ID = a.ID, Description = a.Description, Created = a.Created, IsComplete = a.IsComplete };

            return v.ToList();
        }
    }
}
