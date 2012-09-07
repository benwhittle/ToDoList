using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoList.Model;

namespace ToDoList.UI
{
    public partial class _Default : System.Web.UI.Page
    {
        private ITaskListRepository taskList;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get a concrete ITaskListRepository using the Windsor IOC container.
            taskList = GetConcreteTaskListRepository();

            if (!IsPostBack)
            {
                PopulateLayout();
            }
        }

        private void PopulateLayout()
        {
            grdTasks.DataSource = taskList.ListTasks();
            grdTasks.DataBind();
        }

        protected void DeleteTask(Object sender, GridViewDeleteEventArgs e)
        {
            Guid taskID = Guid.Parse(e.Keys["ID"].ToString());            
            taskList.RemoveTask(taskID);
            PopulateLayout();
        }

        protected void MarkTaskAsComplete(object sender, GridViewUpdateEventArgs e)
        {
            Guid id = Guid.Parse(e.Keys["ID"].ToString());
            taskList.MarkTaskComplete(id);
            PopulateLayout();
        }

        protected void AddNewTask(object sender, EventArgs e)
        {
            taskList.AddTask(txtTaskDescription.Text);
            PopulateLayout();
        }

        private ITaskListRepository GetConcreteTaskListRepository()
        {
            // This is the factory method that gets the concrete ITaskListRepository.
            var container = Application["container"] as IWindsorContainer;
            return container.Resolve<ITaskListRepository>();
        }
    }
}