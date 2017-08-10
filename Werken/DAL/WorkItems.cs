using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Werken.Support;

namespace Werken.DAL
{
	static class WorkItems
	{
		public static List<WorkItem> GetWorkItems( Database db, Week week )
		{
			using( var cn = new SqlConnection( db.ConnectionString ) )
			{
				cn.Open();

				return cn.Query<WorkItem>( "select * from WorkItems where Year=@Year and Week=@Week order by Id", new { Year = week.Year, Week = week.Nr } ).AsList();
			}
		}

		public static void Update( Database db, WorkItem item )
		{
			using( var cn = new SqlConnection( db.ConnectionString ) )
			{
				cn.Open();

				cn.Update<WorkItem>( item );
			}
		}
 	}
}
