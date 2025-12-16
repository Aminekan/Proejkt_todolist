using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace todolist.Models
{
    public class Datenbank
    {
        private static string connectionsql = "Server=localhost;uid=root;pwd=root;database=todo_Amin";

        public List<todolist.Task.Seminar> GetAllTask()
        {
            var tasks = new List<todolist.Task.Seminar>();
            using(var conn = new MySqlConnection(connectionsql))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT `SeminarId`, `Titel`, `Datum` FROM `seminar` WHERE 1",conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new todolist.Task.Seminar()
                            {
                                Id = reader.GetInt32("SeminarId"),
                                Titel = reader.GetString("Titel"),
                                Date = reader.GetDateTime("Datum")
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
            return tasks;

        }
    }
}
