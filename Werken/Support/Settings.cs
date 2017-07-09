using System;

namespace Werken.Support
{
	class Settings
	{
		private Properties.Settings settings;

		public Settings( Properties.Settings settings )
		{
			this.settings = settings;
		}

		public void Save()
		{
			settings.Save();
		}

		public string DatabasePath
		{
			get
			{
				string path = settings.DatabasePath;

				if( string.IsNullOrEmpty( path ) )
					path = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData );

				return path;
			}

			set { settings.DatabasePath = value; }
		}
	}
}
