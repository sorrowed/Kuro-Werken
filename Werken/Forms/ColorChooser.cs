using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Werken.Forms
{
	public partial class ColorChooser : Form
	{
		public Color Color { get; private set; }
		public ColorChooser( Color color )
		{
			InitializeComponent();

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
