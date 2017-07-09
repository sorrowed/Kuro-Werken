using System;
using System.Drawing;
using System.Windows.Forms;

namespace Werken.Forms
{
	public partial class ColorChooser : Form
	{
		public Color Color { get; private set; }
		public ColorChooser( Color color )
		{
			InitializeComponent();

			label6.BackColor = Color.White;
			label1.BackColor = Color.Red;

			label2.BackColor = Color.Yellow;
			label3.BackColor = Color.Green;

			label4.BackColor = Color.Orange;
			label5.BackColor = Color.Blue;

			SelectLabel( Color = color );
		}

		private void SelectLabel( Color color )
		{
			foreach( var ctrl in Controls )
			{
				var label = ctrl as Label;
				if( ctrl == null )
					continue;

				if( label.BackColor == Color )
				{
					label.Select();
					label.Focus();
				}
			}
		}

		private void label_Click( object sender, EventArgs e )
		{
			Color = ( sender as Label ).BackColor;

			DialogResult = DialogResult.OK;
		}

		private void ColorChooser_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.Escape )
				DialogResult = DialogResult.Cancel;

		}
	}
}
