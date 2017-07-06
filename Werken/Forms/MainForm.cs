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

		public MainForm()
		{
			InitializeComponent();

			Items = new List<WorkItem>();

			headerCtrl = new WorkItemHdrCtrl();
			WorkItemsPanel.Controls.Add( headerCtrl );
			headerCtrl.Location = new Point( 0, 0 );
			headerCtrl.Width = WorkItemsPanel.Width;
			headerCtrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

			MainForm_SizeChanged( null, null );
			RemarksList.Items.Add( "Test message 1" );
			RemarksList.Items.Add( "Test message 2" );
		}

		private void MainForm_Load( object sender, EventArgs e )
		{
			Week = new Week( DateTime.Today );
			WorkItemControls = new List<WorkItemCtrl>();

			UpdateView();
			UpdateWorkItems();
		}

		private void UpdateButton_Click( object sender, EventArgs e )
		{
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
		}

		private void NextWeekButton_Click( object sender, EventArgs e )
		{
			Week.Next();

			UpdateView();
			UpdateWorkItems();
		}

		private void WeekNrLabel_Click( object sender, EventArgs e )
		{
			Week.To( DateTime.Today );
			UpdateView();
			UpdateWorkItems();
		}

		private void UpdateView()
		{
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
				ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
				ctrl.Size = new Size( WorkItemsPanel.Width, ctrl.Height );

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
			RemarksList.Columns[ 0 ].Width = RemarksList.ClientSize.Width;
		}
	}
}
