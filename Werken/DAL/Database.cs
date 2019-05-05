using System;
using System.Data.SqlClient;
using System.IO;
using Dapper;

namespace Werken.DAL
{
	public delegate void Reader( SqlDataReader reader );

	class Database
	{
        //public string ConnectionString
        //{
        //	get
        //	{
        //              return @"Server=LAPTOP-TOM\SQLEXPRESS;Database=ProjectView-V1;Trusted_Connection=True;";
        //	}
        //}

        public string ConnectionString
        {
            get
            {
                return @"Server =KUROSERVER;Database=ProjectView-V1;User Id=productie; Password=productie;";
            }
        }

        public void Create()
		{
			using( var cn = new SqlConnection( ConnectionString ) )
			{
				cn.Open();

				using( var tr = cn.BeginTransaction() )
				{
					string sql = @"create table WorkItems ( Id integer primary key identity(1,1),
	                                Year integer not null,
	                                Week integer not null,
	                                OrderNr varchar(128) not null,
	                                ProductionNr varchar(128) default '',
	                                Project varchar(128) default '',
	                                Customer varchar(128) default '',
	                                Chalets integer default 0,
	                                Kozijnen integer default 0,
	                                Ramen integer default 0,
	                                Deuren integer default 0,
	                                Glas varchar(128) default '',
	                                Roosters varchar(128) default '',
	                                Profielen varchar(128) default '',
	                                Panelen varchar(128) default '',
	                                Cilinders varchar(128) default '',
	                                Inzethor varchar(128) default '',
	                                BAZ varchar(128) default '', 
	                                LAS varchar(128) default '', 
	                                AFM varchar(128) default '', 
	                                AWL varchar(128) default '', 
	                                Complete varchar(128) default '',
	                                LeverWeek varchar(128) default '',
	                                Locatie varchar(2048),
	                                Remarks varchar(2048),
	                                GlasColor integer default 0,
	                                RoostersColor integer default 0,
	                                CilindersColor integer default 0,
	                                InzetHorColor integer default 0,
	                                RemarksColor integer default 0 ,
	                                ProfielenColor integer default 0,
	                                PanelenColor integer default 0 )";

					using( var cmd = new SqlCommand( sql, cn, tr ) )
					{
						cmd.ExecuteScalar();
					}

					tr.Commit();

					//InsertTest( cn );
				}

				cn.Close();
			}
		}

		private void InsertTest( SqlConnection cn )
		{
			for( int i = 0; i < 25; ++i )
			{
				cn.ExecuteScalar( @"INSERT INTO WorkItems 
					(
						Year,Week,
						OrderNr,
						ProductionNr,
						Project,
						Customer,
						Chalets,Kozijnen,Ramen,Deuren,
						Glas,Roosters,Cilinders,Inzethor,
						BAZ,LAS,AFM,Complete,Remarks
					) VALUES (
					2017,26,
					2017511,
					121414,
					'Herlevering VEK oude order 2017449',
					'Euro Recreatiebouw',
					0,1,0,0,
					'5-7','5-7','-','X',
					'\','','','', 'Testopmerking')" );
			}

		}
	}
}
