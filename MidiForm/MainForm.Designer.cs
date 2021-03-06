﻿/*
 * Created by SharpDevelop.
 * User: cedric
 * Date: 06/01/2011
 * Time: 10:20 PM
 */
using System.Windows.Forms;

namespace MidiForm
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitForm = new System.Windows.Forms.SplitContainer();
            this.lblOnPause = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.splitMessages = new System.Windows.Forms.SplitContainer();
            this.tbMessages = new System.Windows.Forms.ToolStrip();
            this.tbBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbBtnConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbBtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.tbBtnStop = new System.Windows.Forms.ToolStripButton();
            this.tbBtnPlay = new System.Windows.Forms.ToolStripButton();
            this.tbBtnPause = new System.Windows.Forms.ToolStripButton();
            this.tbBtnNext = new System.Windows.Forms.ToolStripButton();
            this.tbBtnCanevas = new System.Windows.Forms.ToolStripButton();
            this.txtMessages = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitForm)).BeginInit();
            this.splitForm.Panel1.SuspendLayout();
            this.splitForm.Panel2.SuspendLayout();
            this.splitForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMessages)).BeginInit();
            this.splitMessages.Panel1.SuspendLayout();
            this.splitMessages.Panel2.SuspendLayout();
            this.splitMessages.SuspendLayout();
            this.tbMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitForm
            // 
            this.splitForm.BackColor = System.Drawing.SystemColors.Control;
            this.splitForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitForm.Location = new System.Drawing.Point(0, 0);
            this.splitForm.Name = "splitForm";
            this.splitForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitForm.Panel1
            // 
            this.splitForm.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitForm.Panel1.Controls.Add(this.lblOnPause);
            this.splitForm.Panel1.Controls.Add(this.panelButtons);
            // 
            // splitForm.Panel2
            // 
            this.splitForm.Panel2.Controls.Add(this.splitMessages);
            this.splitForm.Size = new System.Drawing.Size(614, 562);
            this.splitForm.SplitterDistance = 465;
            this.splitForm.SplitterWidth = 2;
            this.splitForm.TabIndex = 10;
            // 
            // lblOnPause
            // 
            this.lblOnPause.BackColor = System.Drawing.SystemColors.Info;
            this.lblOnPause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnPause.Location = new System.Drawing.Point(208, 170);
            this.lblOnPause.Name = "lblOnPause";
            this.lblOnPause.Size = new System.Drawing.Size(194, 54);
            this.lblOnPause.TabIndex = 0;
            this.lblOnPause.Text = "On pause";
            this.lblOnPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(610, 461);
            this.panelButtons.TabIndex = 0;
            this.panelButtons.Click += new System.EventHandler(this.panelButtons_Click);
            // 
            // splitMessages
            // 
            this.splitMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMessages.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMessages.IsSplitterFixed = true;
            this.splitMessages.Location = new System.Drawing.Point(0, 0);
            this.splitMessages.Name = "splitMessages";
            this.splitMessages.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMessages.Panel1
            // 
            this.splitMessages.Panel1.Controls.Add(this.tbMessages);
            // 
            // splitMessages.Panel2
            // 
            this.splitMessages.Panel2.Controls.Add(this.txtMessages);
            this.splitMessages.Size = new System.Drawing.Size(610, 91);
            this.splitMessages.SplitterDistance = 25;
            this.splitMessages.SplitterWidth = 1;
            this.splitMessages.TabIndex = 0;
            // 
            // tbMessages
            // 
            this.tbMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBtnRefresh,
            this.tbBtnConfiguration,
            this.toolStripSeparator1,
            this.tbBtnOpen,
            this.tbBtnPrevious,
            this.tbBtnStop,
            this.tbBtnPlay,
            this.tbBtnPause,
            this.tbBtnNext,
            this.tbBtnCanevas});
            this.tbMessages.Location = new System.Drawing.Point(0, 0);
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(610, 25);
            this.tbMessages.TabIndex = 0;
            this.tbMessages.Text = "toolStrip1";
            // 
            // tbBtnRefresh
            // 
            this.tbBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnRefresh.Image")));
            this.tbBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnRefresh.Name = "tbBtnRefresh";
            this.tbBtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tbBtnRefresh.Text = "Refresh the setup";
            this.tbBtnRefresh.Click += new System.EventHandler(this.TbBtnRefreshClick);
            // 
            // tbBtnConfiguration
            // 
            this.tbBtnConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnConfiguration.Image")));
            this.tbBtnConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnConfiguration.Name = "tbBtnConfiguration";
            this.tbBtnConfiguration.Size = new System.Drawing.Size(23, 22);
            this.tbBtnConfiguration.Text = "Configuration";
            this.tbBtnConfiguration.Visible = false;
            this.tbBtnConfiguration.Click += new System.EventHandler(this.TbBtnConfigurationClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbBtnOpen
            // 
            this.tbBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnOpen.Image")));
            this.tbBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnOpen.Name = "tbBtnOpen";
            this.tbBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tbBtnOpen.Text = "Open a setlist";
            this.tbBtnOpen.Click += new System.EventHandler(this.TbBtnOpenClick);
            // 
            // tbBtnPrevious
            // 
            this.tbBtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnPrevious.Image")));
            this.tbBtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnPrevious.Name = "tbBtnPrevious";
            this.tbBtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.tbBtnPrevious.Text = "Previous";
            this.tbBtnPrevious.Click += new System.EventHandler(this.TbBtnPreviousClick);
            // 
            // tbBtnStop
            // 
            this.tbBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnStop.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnStop.Image")));
            this.tbBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnStop.Name = "tbBtnStop";
            this.tbBtnStop.Size = new System.Drawing.Size(23, 22);
            this.tbBtnStop.Text = "Stop";
            this.tbBtnStop.Click += new System.EventHandler(this.TbBtnStopClick);
            // 
            // tbBtnPlay
            // 
            this.tbBtnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnPlay.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnPlay.Image")));
            this.tbBtnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnPlay.Name = "tbBtnPlay";
            this.tbBtnPlay.Size = new System.Drawing.Size(23, 22);
            this.tbBtnPlay.Text = "Play";
            this.tbBtnPlay.Click += new System.EventHandler(this.TbBtnPlayClick);
            // 
            // tbBtnPause
            // 
            this.tbBtnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnPause.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnPause.Image")));
            this.tbBtnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnPause.Name = "tbBtnPause";
            this.tbBtnPause.Size = new System.Drawing.Size(23, 22);
            this.tbBtnPause.Text = "Pause";
            this.tbBtnPause.Click += new System.EventHandler(this.TbBtnPauseClick);
            // 
            // tbBtnNext
            // 
            this.tbBtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnNext.Image")));
            this.tbBtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnNext.Name = "tbBtnNext";
            this.tbBtnNext.Size = new System.Drawing.Size(23, 22);
            this.tbBtnNext.Text = "Next";
            this.tbBtnNext.Click += new System.EventHandler(this.TbBtnNextClick);
            // 
            // tbBtnCanevas
            // 
            this.tbBtnCanevas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBtnCanevas.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnCanevas.Image")));
            this.tbBtnCanevas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnCanevas.Name = "tbBtnCanevas";
            this.tbBtnCanevas.Size = new System.Drawing.Size(23, 22);
            this.tbBtnCanevas.Text = "Show black canevas";
            this.tbBtnCanevas.ToolTipText = "Show black canevas";
            this.tbBtnCanevas.Click += new System.EventHandler(this.tbBtnCanevasClick);
            // 
            // txtMessages
            // 
            this.txtMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(0, 0);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(610, 65);
            this.txtMessages.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 562);
            this.Controls.Add(this.splitForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Midi Mp3/Video Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.splitForm.Panel1.ResumeLayout(false);
            this.splitForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitForm)).EndInit();
            this.splitForm.ResumeLayout(false);
            this.splitMessages.Panel1.ResumeLayout(false);
            this.splitMessages.Panel1.PerformLayout();
            this.splitMessages.Panel2.ResumeLayout(false);
            this.splitMessages.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMessages)).EndInit();
            this.splitMessages.ResumeLayout(false);
            this.tbMessages.ResumeLayout(false);
            this.tbMessages.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripButton tbBtnConfiguration;
		private System.Windows.Forms.ToolStripButton tbBtnNext;
		private System.Windows.Forms.ToolStripButton tbBtnPrevious;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbBtnPlay;
		private System.Windows.Forms.Label lblOnPause;
		private System.Windows.Forms.ToolStripButton tbBtnOpen;
		private System.Windows.Forms.ToolStripButton tbBtnRefresh;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.ToolStripButton tbBtnPause;
		private System.Windows.Forms.ToolStripButton tbBtnStop;
		private System.Windows.Forms.ToolStrip tbMessages;
		private System.Windows.Forms.SplitContainer splitMessages;
		private System.Windows.Forms.SplitContainer splitForm;
		private System.Windows.Forms.TextBox txtMessages;

		void MainFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
			this.removeInputDevice();
            this.DisposeAllVideos();
		}
		
		void TbBtnRefreshClick(object sender, System.EventArgs e) {
			this.removeInputDevice();
			InitializeInputDevice();
		}
		
		void TbBtnOpenClick(object sender, System.EventArgs e){
			//Opens a dialog choosing the file
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == DialogResult.OK) {
				
				if (dlg.FileName.Substring(dlg.FileName.Length - 4) == ".xml") {
					
		            //Initialize the file
					ReadSetlistFile(dlg.FileName);
					
					//Rebuild the new setlist
					InitializeSetlist();
				}
	        }
		}
		
		void TbBtnPreviousClick(object sender, System.EventArgs e) {
			this.doPrevious();
		}
		
		void TbBtnStopClick(object sender, System.EventArgs e) {
			this.doStop();
		}
		
		void TbBtnPlayClick(object sender, System.EventArgs e) {
			this.doPlay();
		}
		
		void TbBtnPauseClick(object sender, System.EventArgs e) {
			checkPause = !checkPause;
			tbBtnPause.Checked = checkPause;
			
			this.lblOnPause.Visible = checkPause;
			if (checkPause) {
				this.lblOnPause.Left = (this.panelButtons.Width / 2 - this.lblOnPause.Width / 2);
				this.lblOnPause.Top = (this.panelButtons.Height / 2 - this.lblOnPause.Height / 2);
            }
		}
		
		void TbBtnNextClick(object sender, System.EventArgs e) {
			this.doNext();
		}
		
		void TbBtnConfigurationClick(object sender, System.EventArgs e) {
			Configuration configuration = new Configuration();
			configuration.ShowDialog();
		}
		
		private void Video_MouseEnter(object sender, System.EventArgs e) {
			Cursor.Hide();
		}
		
		private void Video_MouseLeave(object sender, System.EventArgs e) {
			Cursor.Show();
		}

        private void panelButtons_Click(object sender, System.EventArgs e) {
            this.panelButtons.Focus();
        }

        private ToolStripButton tbBtnCanevas;
	}
}
