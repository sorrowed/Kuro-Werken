using System;
using System.Drawing;
using System.Windows.Forms;
using Werken.Forms;
using Werken.Support;

namespace Werken.Controls
{
	public partial class WorkItemCtrl : UserControl
	{
		public event Action<WorkItemCtrl> Clicked;

		private bool emphasize;

		public bool Emphasize
		{
			get { return emphasize; }
			set { emphasize = value; SetBackGround(); }
		}

		private void SetBackGround()
		{
			BackColor = emphasize ? SystemColors.ControlDarkDark : SystemColors.Control;
		}

		public WorkItem Item { get; private set; }

		public WorkItemCtrl()
		{
			InitializeComponent();
		}

		public void Assign( WorkItem item )
		{
			Item = item;

			Bind();
		}

		private void Draw()
		{
			if( ProductionNrTextBox.Text.ToLowerInvariant() == "oke" )
				ProductionNrTextBox.BackColor = Color.DarkGreen;
			else
				ProductionNrTextBox.BackColor = SystemColors.Window ;
		}

		private void Bind()
		{
			OrderNrLabel.DataBindings.Add( new Binding( "Text", Item, "OrderNr",false, DataSourceUpdateMode.OnPropertyChanged ) );
			ProductionNrTextBox.DataBindings.Add( new Binding( "Text", Item, "ProductionNr", false, DataSourceUpdateMode.OnValidation ) );
			ProjectLabal.DataBindings.Add( new Binding( "Text", Item, "Project", false, DataSourceUpdateMode.OnPropertyChanged ) );
			CustomerLabel.DataBindings.Add( new Binding( "Text", Item, "Customer", false, DataSourceUpdateMode.OnPropertyChanged ) );

			ChaletsLabel.DataBindings.Add( new Binding( "Text", Item, "Chalets", false, DataSourceUpdateMode.OnPropertyChanged ) );
			KozijnenLabel.DataBindings.Add( new Binding( "Text", Item, "Kozijnen", false, DataSourceUpdateMode.OnPropertyChanged ) );
			RamenLabel.DataBindings.Add( new Binding( "Text", Item, "Ramen", false, DataSourceUpdateMode.OnPropertyChanged ) );
			DeurenLabel.DataBindings.Add( new Binding( "Text", Item, "Deuren", false, DataSourceUpdateMode.OnPropertyChanged ) );

			var binding = new Binding( "Text", Item, "Glas", false, DataSourceUpdateMode.OnValidation );
			binding.Format += Binding_TryFormatDate;
			GlassTextBox.DataBindings.Add( binding );
			binding = new Binding( "BackColor", Item, "GlasColor", false, DataSourceUpdateMode.OnPropertyChanged );
			binding.Format += Binding_TryFormatColor;
			binding.Parse += Binding_TryParseColor;
			GlassTextBox.DataBindings.Add( binding );

			binding = new Binding( "Text", Item, "Roosters", false, DataSourceUpdateMode.OnValidation );
			binding.Format += Binding_TryFormatDate;
			RoosterTextBox.DataBindings.Add( binding );
			binding = new Binding( "BackColor", Item, "RoostersColor", false, DataSourceUpdateMode.OnPropertyChanged );
			binding.Format += Binding_TryFormatColor;
			binding.Parse += Binding_TryParseColor;
			RoosterTextBox.DataBindings.Add( binding );

			binding = new Binding( "Text", Item, "Cilinders", false, DataSourceUpdateMode.OnValidation );
			binding.Format += Binding_TryFormatDate;
			CilindersTextBox.DataBindings.Add( binding );
			binding = new Binding( "BackColor", Item, "CilindersColor", false, DataSourceUpdateMode.OnPropertyChanged );
			binding.Format += Binding_TryFormatColor;
			binding.Parse += Binding_TryParseColor;
			CilindersTextBox.DataBindings.Add( binding );

			binding = new Binding( "Text", Item, "Inzethor", false, DataSourceUpdateMode.OnValidation );
			binding.Format += Binding_TryFormatDate;
			InzethorTextBox.DataBindings.Add( binding );
			binding = new Binding( "BackColor", Item, "InzethorColor", false, DataSourceUpdateMode.OnPropertyChanged );
			binding.Format += Binding_TryFormatColor;
			binding.Parse += Binding_TryParseColor;
			InzethorTextBox.DataBindings.Add( binding );


			BazTextBox.DataBindings.Add( new Binding( "Text", Item, "BAZ", false, DataSourceUpdateMode.OnPropertyChanged ) );
			LasTextBox.DataBindings.Add( new Binding( "Text", Item, "LAS", false, DataSourceUpdateMode.OnPropertyChanged ) );
			AfmTextBox.DataBindings.Add( new Binding( "Text", Item, "AFM", false, DataSourceUpdateMode.OnPropertyChanged ) );
			CompleteTextBox.DataBindings.Add( new Binding( "Text", Item, "Complete", false, DataSourceUpdateMode.OnPropertyChanged ) );

			RemarksTextBox.DataBindings.Add( new Binding( "Text", Item, "Remarks", false, DataSourceUpdateMode.OnPropertyChanged ) );
		}

		private void Binding_TryFormatColor( object sender, ConvertEventArgs e )
		{
			if( e.DesiredType != typeof( Color ) )
				return;

			int c = (int)e.Value;
			if( c == 0 )
				e.Value = SystemColors.Window;
			else
				e.Value = ColorUtils.ExcelToNet( c );
		}

		private void Binding_TryParseColor( object sender, ConvertEventArgs e )
		{
			if( e.DesiredType != typeof( int ) )
				return;

			e.Value = ColorUtils.NetToExcel( (Color)e.Value );
		}

		private void Binding_TryFormatDate( object sender, ConvertEventArgs e )
		{
			if( e.DesiredType != typeof(string) )
				return;

			DateTime d;
			if( !DateTime.TryParse( e.Value as string, out d ) )
				return;

			e.Value = d.ToString( "dd-MM" );

		}

		private void textBox_Enter( object sender, EventArgs e )
		{
			var t = sender as TextBox;
			if( t == null )
				return;
			t.SelectAll();
		}

		private void WorkItemCtrl_SizeChanged( object sender, EventArgs e )
		{
			int top = ( Height - GlassTextBox.Height ) / 2;
			int height = GlassTextBox.Height;

			foreach( Control control in Controls )
			{
				control.Height = height;
				control.Top = top;
			}
		}

		private void BazTextBox_MouseDown( object sender, MouseEventArgs e )
		{
			var t = sender as Label;
			if( t == null )
				return;

			if( string.IsNullOrEmpty( t.Text ) )
				t.Text = @"\";
			else if( t.Text == @"\" )
				t.Text = @"x";
			else
				t.Text = string.Empty;
		}

		private void Control_Click( object sender, EventArgs e )
		{
			if( Clicked != null )
				Clicked( this );
		}

		private void InzethorTextBox_MouseDown( object sender, MouseEventArgs e )
		{
			if( e.Button != MouseButtons.Right )
				return;

			var tb = sender as TextBox;
			if( tb == null )
				return;

			using( var dlg = new ColorChooser( tb.BackColor ) )
			{
				var l = Location;
				l.Offset( tb.Location );
				dlg.Location = l;

				if( dlg.ShowDialog() == DialogResult.OK )
					tb.BackColor = dlg.Color;
			}
		}

		private void WorkItemCtrl_Load( object sender, EventArgs e )
		{
			WorkItemCtrl_SizeChanged(null,null);
			Draw();
		}

		private void RemarksTextBox_Leave( object sender, EventArgs e )
		{
			Draw();
		}

		private void WorkItemCtrl_Validated( object sender, EventArgs e )
		{
			Draw();
		}
	}
}
