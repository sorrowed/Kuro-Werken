using System.Drawing;
using System.Linq;

namespace Werken.Support
{
	public static class ColorUtils
	{
		public static int NetToExcel( Color color )
		{
			var c = Color.FromArgb( 255, color.B, color.G, color.R );

			return c.ToArgb();
		}

		public static Color ExcelToNet( int color )
		{
			var c = Color.FromArgb( color );

			return Color.FromArgb( 255, c.B, c.G, c.R );
		}
	}
}
