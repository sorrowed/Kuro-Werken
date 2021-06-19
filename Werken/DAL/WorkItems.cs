using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using Dapper;
using Dapper.Contrib.Extensions;
using Werken.Support;

namespace Werken.DAL
{
    static class WorkItems
    {
        public static List<WorkItem> GetWorkItems(Database db, Week week)
        {
            using (var cn = new SqlConnection(db.ConnectionString))
            {
                cn.Open();

                return cn.Query<WorkItem>("select * from WorkItems where Year=@Year and Week=@Week order by Id", new { Year = week.Y, Week = week.W }).AsList();
            }
        }

        public static void Update(Database db, WorkItem item)
        {
            using (var cn = new SqlConnection(db.ConnectionString))
            {
                cn.Open();

                cn.Update<WorkItem>(item);
            }
        }

        /// <summary>
        /// Update a single column
        /// </summary>
        public static WorkItem Update(Database db, WorkItem item, string propertyName)
        {
            var result = item;

            PropertyInfo[] props = item.GetType().GetProperties();
            var property = Array.Find(props, p => p.Name == propertyName);

            try
            {
                string sql = string.Format("UPDATE WorkItems SET {0} = @Value WHERE Id = @Id;", propertyName);

                using (var cn = new SqlConnection(db.ConnectionString))
                {
                    cn.Open();

                    cn.Execute(sql, new { item.Id, Value = property.GetValue(item) });

                    result = cn.Get<WorkItem>(item.Id);
                }
            }
            catch
            {
                Update(db, item);
            }

            return result;
        }
    }
}
