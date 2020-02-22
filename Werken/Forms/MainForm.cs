using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Werken.Controls;
using Werken.DAL;
using Werken.Support;

namespace Werken.Forms
{
	public partial class MainForm : Form
	{
		private Week Week { get; set; }
		private List<WorkItem> Items { get; set; }
		private List<WorkItemCtrl> WorkItemControls{ get; set; }

		private WorkItemHdrCtrl headerCtrl;

		private Settings settings;

		private bool configurationView;

		public MainForm()
		{
			InitializeComponent();

			Items = new List<WorkItem>();
			WorkItemControls = new List<WorkItemCtrl>();

			Week = new Week( DateTime.Today );

			settings = new Settings( Properties.Settings.Default );

			headerCtrl = new WorkItemHdrCtrl();
			WorkItemsPanel.Controls.Add( headerCtrl );
			headerCtrl.Location = new Point( 0, 0 );
			headerCtrl.Width = WorkItemsPanel.Width;
			headerCtrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

			MainForm_SizeChanged( null, null );
		}

		private void MainForm_Load( object sender, EventArgs e )
		{

			//var db = new Database();
			//db.Create();


			UpdateView();
			UpdateWorkItems();
		}


		private void UpdateButton_Click( object sender, EventArgs e )
		{
			UpdateView();
			UpdateWorkItems();
			UpdateControls();
		}

		private void CreateButton_Click( object sender, EventArgs e )
		{
			var db = new Database();
			db.Create();
		}

		private void PreviousWeekButton_Click( object sender, EventArgs e )
		{
			Week.Previous();
			UpdateView();
			UpdateWorkItems();
			UpdateControls();
		}

		private void NextWeekButton_Click( object sender, EventArgs e )
		{
			Week.Next();

			UpdateView();
			UpdateWorkItems();
			UpdateControls();
		}

		private void WeekNrLabel_Click( object sender, EventArgs e )
		{
			Week.To( DateTime.Today );
			UpdateView();
			UpdateWorkItems();
			UpdateControls();
		}

		private void UpdateView()
		{
			SetDatabasePathButton.Visible = 
				CreateDatabasePathButton.Visible = configurationView;
			
			YearLabel.Text = Week.Y.ToString();
			WeekNrLabel.Text = Week.W.ToString();
			FromLabel.Text = Week.Get( DayOfWeek.Monday ).ToShortDateString();
			ToLabel.Text = Week.Get( DayOfWeek.Friday ).ToShortDateString();
		}

		private void UpdateWorkItems()
		{
			foreach( var item in Items )
				item.PropertyChanged -= Item_PropertyChanged;

			Items = WorkItems.GetWorkItems( new Database(), Week );
			foreach( var item in Items )
				item.PropertyChanged += Item_PropertyChanged;

			WorkItemsPanel.SuspendLayout();

			foreach( var ctrl in WorkItemControls )
			{
				ctrl.Clicked -= Ctrl_Clicked;
                ctrl.Deassign();
                WorkItemsPanel.Controls.Remove( ctrl );
			}

			WorkItemControls.Clear();

			int y = headerCtrl.Bottom;
			foreach( var item in Items )
			{
				if( item.IsRemarkRow() )
					continue;

				var ctrl = new WorkItemCtrl();
				ctrl.Assign( item );

				WorkItemsPanel.Controls.Add( ctrl );

				ctrl.Location = new Point( 0, y );
				ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				y += ( ctrl.Height );

				ctrl.Clicked += Ctrl_Clicked;
				WorkItemControls.Add( ctrl );
            }

			WorkItemsPanel.ResumeLayout();

            RemarksList.SuspendLayout();
			RemarksList.Items.Clear();
			foreach( var item in Items )
			{
				if( !item.IsRemarkRow() )
					continue;

				RemarksList.Items.Add( item.Project );
			}
			RemarksList.ResumeLayout();
		}

		private void UpdateControls()
		{
			RemarksList.Columns[ 0 ].Width = RemarksList.ClientSize.Width;

            foreach (var ctrl in WorkItemControls)
                ctrl.Width = WorkItemsPanel.ClientSize.Width;
        }

		private void Ctrl_Clicked( WorkItemCtrl obj )
		{
			foreach( var ctrl in WorkItemControls )
				ctrl.Emphasize = object.ReferenceEquals( ctrl, obj );
		}

		private void Item_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			WorkItems.Update( new Database(), sender as WorkItem );
		}

		private void MainForm_SizeChanged( object sender, EventArgs e )
		{
			UpdateControls();
		}

		private void SetDatabasePath_Click( object sender, EventArgs e )
		{
			using( var dlg = new FolderBrowserDialog () )
			{
				dlg.SelectedPath = settings.DatabasePath;

				if( dlg.ShowDialog( this ) != DialogResult.OK )
					return;

				settings.DatabasePath = dlg.SelectedPath;

				settings.Save();

			}
		}

		private void MainForm_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.C && e.Alt && e.Control )
				configurationView = !configurationView;
			UpdateView();

			if( e.KeyCode == Keys.C && !e.Alt && e.Control )
				CopyItems();

			if( e.KeyCode == Keys.A && !e.Alt && e.Control )
				SelectAllItems();
			if( e.KeyCode == Keys.N && !e.Alt && e.Control )
				SelectNoItems();
			if( e.KeyCode == Keys.I && !e.Alt && e.Control )
				SelectInvertItems();
		}

		private void SelectNoItems()
		{
			foreach( var ctrl in WorkItemControls )
				ctrl.IsSelected = false;
		}

		private void SelectAllItems()
		{
			foreach( var ctrl in WorkItemControls )
				ctrl.IsSelected = true;
		}

		private void SelectInvertItems()
		{
			foreach( var ctrl in WorkItemControls )
				ctrl.IsSelected = !ctrl.IsSelected;
		}

		private void CopyItems()
		{
			var selectedItems = new List<WorkItem>();
			foreach( var ctrl in WorkItemControls )
			{
				if( ctrl.IsSelected )
					selectedItems.Add( ctrl.Item );
			}

			if( selectedItems.Count < 1 )
				return;

			var builder = new StringBuilder();
			foreach( var item in selectedItems )
			{
				builder.AppendLine( string.Join( "\t", item.OrderNr, item.ProductionNr, item.Project, item.Customer, item.LeverWeek, item.Locatie ) );
			}

			Clipboard.SetText( builder.ToString() );
		}
	}
}
