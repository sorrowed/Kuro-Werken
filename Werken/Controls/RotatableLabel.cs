using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Werken.Controls
{
	class RotatableLabel : Control
	{
		public RotatableLabel()
		{
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
		}

		protected override void OnPaint( PaintEventArgs e )
		{
			var g = e.Graphics;

			g.DrawRectangle( Pens.Black, 0, 0, Width - 1, Height - 1 );

			g.InterpolationMode = InterpolationMode.High;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

			g.TranslateTransform( 0,Height );
			g.RotateTransform( -90 );

			var r = new Rectangle( ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Height, ClientRectangle.Width );

			using( var fmt = new StringFormat() )
			{
				fmt.Alignment = StringAlignment.Center;
				fmt.LineAlignment = StringAlignment.Center;

				g.DrawString( Text, Font, Brushes.Black, r, fmt );
			}
		}
	}
}
