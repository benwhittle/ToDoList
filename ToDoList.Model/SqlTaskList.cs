using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ToDoList.Model
{
    public class SqlTaskList : ITaskListRepository
    {
        private string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Tasks"].ConnectionString; }
        }

        public void AddTask(string description)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Tasks_Add";
                    cmd.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar) { Value = description });

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveTask(Guid id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Tasks_Delete";
                    cmd.Parameters.Add(new SqlParameter("ID", System.Data.SqlDbType.UniqueIdentifier) { Value = id });

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MarkTaskComplete(Guid id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Tasks_MarkAsComplete";
                    cmd.Parameters.Add(new SqlParameter("ID", System.Data.SqlDbType.UniqueIdentifier) { Value = id });

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ICollection<ToDoListItem> ListTasks()
        {
            List<ToDoListItem> tasks = new List<ToDoListItem>();

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Tasks_GetAll";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ToDoListItem task = new ToDoListItem() { ID = reader.GetGuid(0), Description = reader.GetString(1), Created = reader.GetDateTime(2), IsComplete = reader.GetBoolean(3) };
                        tasks.Add(task);
                    }
                    reader.Close();
                }
            }

            return tasks;
        }
    }
}
