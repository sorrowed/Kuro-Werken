﻿namespace Werken
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.UpdateButton = new System.Windows.Forms.Button();
			this.CreateButton = new System.Windows.Forms.Button();
			this.WeekNrLabel = new System.Windows.Forms.Label();
			this.NextWeekButton = new System.Windows.Forms.Button();
			this.PreviousWeekButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.YearLabel = new System.Windows.Forms.Label();
			this.FromLabel = new System.Windows.Forms.Label();
			this.ToLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.WorkItemsPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// UpdateButton
			// 
			this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UpdateButton.Location = new System.Drawing.Point(858, 671);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new System.Drawing.Size(138, 46);
			this.UpdateButton.TabIndex = 0;
			this.UpdateButton.Text = "Bijwerken";
			this.UpdateButton.UseVisualStyleBackColor = true;
			this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// CreateButton
			// 
			this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateButton.Location = new System.Drawing.Point(12, 671);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(138, 46);
			this.CreateButton.TabIndex = 1;
			this.CreateButton.Text = "Database maken";
			this.CreateButton.UseVisualStyleBackColor = true;
			this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// WeekNrLabel
			// 
			this.WeekNrLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.WeekNrLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WeekNrLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.WeekNrLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WeekNrLabel.Location = new System.Drawing.Point(156, 12);
			this.WeekNrLabel.Name = "WeekNrLabel";
			this.WeekNrLabel.Size = new System.Drawing.Size(59, 47);
			this.WeekNrLabel.TabIndex = 2;
			this.WeekNrLabel.Text = "53";
			this.WeekNrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.WeekNrLabel.Click += new System.EventHandler(this.WeekNrLabel_Click);
			// 
			// NextWeekButton
			// 
			this.NextWeekButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.NextWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NextWeekButton.Location = new System.Drawing.Point(221, 12);
			this.NextWeekButton.Name = "NextWeekButton";
			this.NextWeekButton.Size = new System.Drawing.Size(52, 47);
			this.NextWeekButton.TabIndex = 3;
			this.NextWeekButton.Text = ">";
			this.NextWeekButton.UseVisualStyleBackColor = false;
			this.NextWeekButton.Click += new System.EventHandler(this.NextWeekButton_Click);
			// 
			// PreviousWeekButton
			// 
			this.PreviousWeekButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.PreviousWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PreviousWeekButton.Location = new System.Drawing.Point(12, 12);
			this.PreviousWeekButton.Name = "PreviousWeekButton";
			this.PreviousWeekButton.Size = new System.Drawing.Size(52, 47);
			this.PreviousWeekButton.TabIndex = 4;
			this.PreviousWeekButton.Text = "<";
			this.PreviousWeekButton.UseVisualStyleBackColor = false;
			this.PreviousWeekButton.Click += new System.EventHandler(this.PreviousWeekButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelButton.Location = new System.Drawing.Point(714, 671);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(138, 46);
			this.CancelButton.TabIndex = 5;
			this.CancelButton.Text = "Annuleren";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// YearLabel
			// 
			this.YearLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.YearLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.YearLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.YearLabel.Location = new System.Drawing.Point(70, 12);
			this.YearLabel.Name = "YearLabel";
			this.YearLabel.Size = new System.Drawing.Size(80, 47);
			this.YearLabel.TabIndex = 7;
			this.YearLabel.Text = "2017";
			this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FromLabel
			// 
			this.FromLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FromLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FromLabel.Location = new System.Drawing.Point(279, 12);
			this.FromLabel.Name = "FromLabel";
			this.FromLabel.Size = new System.Drawing.Size(150, 47);
			this.FromLabel.TabIndex = 8;
			this.FromLabel.Text = "31-12-9999";
			this.FromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ToLabel
			// 
			this.ToLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ToLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ToLabel.Location = new System.Drawing.Point(480, 12);
			this.ToLabel.Name = "ToLabel";
			this.ToLabel.Size = new System.Drawing.Size(150, 47);
			this.ToLabel.TabIndex = 9;
			this.ToLabel.Text = "31-12-9999";
			this.ToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(419, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 47);
			this.label1.TabIndex = 10;
			this.label1.Text = "t/m";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WorkItemsPanel
			// 
			this.WorkItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WorkItemsPanel.AutoScroll = true;
			this.WorkItemsPanel.Location = new System.Drawing.Point(12, 81);
			this.WorkItemsPanel.Name = "WorkItemsPanel";
			this.WorkItemsPanel.Size = new System.Drawing.Size(984, 566);
			this.WorkItemsPanel.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.WorkItemsPanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ToLabel);
			this.Controls.Add(this.FromLabel);
			this.Controls.Add(this.YearLabel);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.PreviousWeekButton);
			this.Controls.Add(this.NextWeekButton);
			this.Controls.Add(this.WeekNrLabel);
			this.Controls.Add(this.CreateButton);
			this.Controls.Add(this.UpdateButton);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainForm";
			this.Text = "Overzicht werken";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Button CreateButton;
		private System.Windows.Forms.Label WeekNrLabel;
		private System.Windows.Forms.Button NextWeekButton;
		private System.Windows.Forms.Button PreviousWeekButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label YearLabel;
		private System.Windows.Forms.Label FromLabel;
		private System.Windows.Forms.Label ToLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel WorkItemsPanel;
	}
}

