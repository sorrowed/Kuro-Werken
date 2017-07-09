using System;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace Werken.DAL
{
	public delegate void Reader( SQLiteDataReader reader );

	class Database
	{
		public string DatabaseFileName { get; set; }

		public string ConnectionString
		{
			get
			{
				return string.Format( @"Data Source={0};foreign keys=true;", DatabaseFileName );
			}
		}

		public Database( string path )
		{
			DatabaseFileName = Path.Combine( path, "Werken.sqlite" );
		}

		public void Create()
		{
			if( File.Exists( DatabaseFileName ) )
				return;

			SQLiteConnection.CreateFile( DatabaseFileName );	

			using( var cn = new SQLiteConnection( ConnectionString ) )
			{
				cn.Open();

				using( var tr = cn.BeginTransaction() )
				{
					string sql = @"create table WorkItems ( 
										Id integer primary key asc,
										Year integer not null,
										Week integer not null,
										OrderNr varchar not null,
										ProductionNr varchar default '',
										Project varchar default '',
										Customer varchar default '',
										Chalets integer default 0,
										Kozijnen integer default 0,
										Ramen integer default 0,
										Deuren integer default 0,
										Glas varchar default '',
										Roosters varchar default '',
										Cilinders varchar default '',
										Inzethor varchar default '',
										BAZ varchar default '', 
										LAS varchar default '', 
										AFM varchar default '', 
										Complete varchar default '',
										Remarks varchar,
										GlasColor integer default 0,
										RoostersColor integer default 0,
										CilindersColor integer default 0,
										InzethorColor integer default 0 )";

					using( var cmd = new SQLiteCommand( sql, cn ) )
					{
						cmd.ExecuteScalar();
					}

					tr.Commit();

					//InsertTest( cn );
				}

				cn.Close();
			}
		}

		private void InsertTest( SQLiteConnection cn )
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
