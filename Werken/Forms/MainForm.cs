using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
			
			YearLabel.Text = Week.Year.ToString();
			WeekNrLabel.Text = Week.Nr.ToString();
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
				//ctrl.Size = new Size( ctrl.Width, ctrl.Height );
				//ctrl.Width = 5000;
				y += ( ctrl.Height + 1 );

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

			foreach( var ctrl in WorkItemControls )
				ctrl.Width = WorkItemsPanel.Width - 6;		}

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
		}
	}
}
