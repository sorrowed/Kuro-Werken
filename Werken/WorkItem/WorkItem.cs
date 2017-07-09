using System.ComponentModel;

namespace Werken
{
	public class WorkItem: INotifyPropertyChanged
	{
		public int Id { get; set; }

		public string OrderNr { get; set; }
		private string productionNr;
		public string ProductionNr { get { return productionNr; } set { if( productionNr != value ) { productionNr = value; Notify( "ProductionNr" ); } } }

		public string Project { get; set; }
		public string Customer { get; set; }

		public int Chalets { get; set; }
		public int Kozijnen { get; set; }
		public int Ramen { get; set; }
		public int Deuren { get; set; }

		private string glas;
		public string Glas { get { return glas; } set { if( glas != value ) { glas = value; Notify( "Glas" ); } } }
		private string roosters;
		public string Roosters { get { return roosters; } set { if( roosters != value ) { roosters = value; Notify( "Roosters" ); } } }
		private string cilinders;
		public string Cilinders { get { return cilinders; } set { if( cilinders != value ) { cilinders = value; Notify( "Cilinders" ); } } }
		private string inzethor;
		public string Inzethor { get { return inzethor; } set { if( inzethor != value ) { inzethor = value; Notify( "Inzethor" ); } } }

		private string baz;
		public string BAZ { get { return baz; } set { if( baz != value ) { baz = value; Notify( "BAZ" ); } } }

		private string las;
		public string LAS { get { return las; } set { if( las != value ) { las = value; Notify( "LAS" ); } } }

		private string afm;
		public string AFM { get { return afm; } set { if( afm != value ) { afm = value; Notify( "AFM" ); } } }

		private string complete;
		public string Complete { get { return complete; } set { if( complete != value ) { complete = value; Notify( "Complete" ); } } }

		private string remarks;
		public string Remarks { get { return remarks; } set { if( remarks != value ) { remarks = value; Notify( "Remarks" ); } } }

		private int glasColor;
		public int GlasColor { get { return glasColor; } set { if( glasColor != value ) { glasColor = value; Notify( "GlasColor" ); } } }
		private int roostersColor;
		public int RoostersColor { get { return roostersColor; } set { if( roostersColor != value ) { roostersColor = value; Notify( "RoostersColor" ); } } }
		private int cilindersColor;
		public int CilindersColor { get { return cilindersColor; } set { if( cilindersColor != value ) { cilindersColor = value; Notify( "CilindersColor" ); } } }
		private int inzethorColor;
		public int InzethorColor { get { return inzethorColor; } set { if( inzethorColor != value ) { inzethorColor = value; Notify( "InzethorColor" ); } } }


		public event PropertyChangedEventHandler PropertyChanged;
		private void Notify(string name )
		{
			if( PropertyChanged != null )
				PropertyChanged( this, new PropertyChangedEventArgs( name ) );
		}
	}

	public static class WorkItemUtils
	{
		public static bool IsEmptyRow( this WorkItem item )
		{
				return string.IsNullOrEmpty( item.OrderNr ) &&
					string.IsNullOrEmpty( item.ProductionNr ) &&
					string.IsNullOrEmpty( item.Customer );
		}

		public static bool IsRemarkRow( this WorkItem item )
		{
				return item.IsEmptyRow() &&
					!string.IsNullOrEmpty( item.Project );
		}
	}
}
