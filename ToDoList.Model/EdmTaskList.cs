using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    public class EdmTaskList : ITaskListRepository
    {
        private ToDoListEntities entities = new ToDoListEntities();

        public void AddTask(string description)
        {
            entities.AddToTasks(new Task() { ID = Guid.NewGuid(), Description = description, Created = DateTime.Now, IsComplete = false });
            entities.SaveChanges();
        }

        public void RemoveTask(Guid id)
        {
            var v = entities.Tasks.FirstOrDefault(t => t.ID == id);
            if (v != null)
            {
                entities.DeleteObject(v);
                entities.SaveChanges();
            }
        }

        public void MarkTaskComplete(Guid id)
        {
            var v = entities.Tasks.FirstOrDefault(t => t.ID == id);
            if (v != null)
            {
                v.IsComplete = true;
                entities.SaveChanges();
            }
        }

        public ICollection<ToDoListItem> ListTasks()
        {
            var tasks = from a in entities.Tasks
                        orderby a.IsComplete, a.Created
                        select new ToDoListItem() { ID = a.ID, Description = a.Description, Created = a.Created, IsComplete = a.IsComplete };

            return tasks.ToList();
        }
    }
}
