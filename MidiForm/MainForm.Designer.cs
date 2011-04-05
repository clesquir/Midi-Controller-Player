/*
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
			this.tbButtonOpen = new System.Windows.Forms.ToolStripButton();
			this.tbBtnStop = new System.Windows.Forms.ToolStripButton();
			this.tbBtnPlay = new System.Windows.Forms.ToolStripButton();
			this.tbBtnPause = new System.Windows.Forms.ToolStripButton();
			this.txtMessages = new System.Windows.Forms.TextBox();
			this.splitForm.Panel1.SuspendLayout();
			this.splitForm.Panel2.SuspendLayout();
			this.splitForm.SuspendLayout();
			this.splitMessages.Panel1.SuspendLayout();
			this.splitMessages.Panel2.SuspendLayout();
			this.splitMessages.SuspendLayout();
			this.tbMessages.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitForm
			// 
			this.splitForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitForm.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitForm.IsSplitterFixed = true;
			this.splitForm.Location = new System.Drawing.Point(0, 0);
			this.splitForm.Name = "splitForm";
			this.splitForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitForm.Panel1
			// 
			this.splitForm.Panel1.Controls.Add(this.lblOnPause);
			this.splitForm.Panel1.Controls.Add(this.panelButtons);
			// 
			// splitForm.Panel2
			// 
			this.splitForm.Panel2.Controls.Add(this.splitMessages);
			this.splitForm.Size = new System.Drawing.Size(614, 562);
			this.splitForm.SplitterDistance = 465;
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
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelButtons.Location = new System.Drawing.Point(0, 0);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(614, 465);
			this.panelButtons.TabIndex = 8;
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
			this.splitMessages.Size = new System.Drawing.Size(614, 93);
			this.splitMessages.SplitterDistance = 25;
			this.splitMessages.TabIndex = 0;
			// 
			// tbMessages
			// 
			this.tbMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tbBtnRefresh,
									this.tbButtonOpen,
									this.tbBtnStop,
									this.tbBtnPlay,
									this.tbBtnPause});
			this.tbMessages.Location = new System.Drawing.Point(0, 0);
			this.tbMessages.Name = "tbMessages";
			this.tbMessages.Size = new System.Drawing.Size(614, 25);
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
			// tbButtonOpen
			// 
			this.tbButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tbButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbButtonOpen.Image")));
			this.tbButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbButtonOpen.Name = "tbButtonOpen";
			this.tbButtonOpen.Size = new System.Drawing.Size(23, 22);
			this.tbButtonOpen.Text = "Open a setlist";
			this.tbButtonOpen.Click += new System.EventHandler(this.TbButtonOpenClick);
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
			// txtMessages
			// 
			this.txtMessages.Cursor = System.Windows.Forms.Cursors.Default;
			this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMessages.Location = new System.Drawing.Point(0, 0);
			this.txtMessages.Multiline = true;
			this.txtMessages.Name = "txtMessages";
			this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessages.Size = new System.Drawing.Size(614, 64);
			this.txtMessages.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 562);
			this.Controls.Add(this.splitForm);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Midi Mp3/Video Controller";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.splitForm.Panel1.ResumeLayout(false);
			this.splitForm.Panel2.ResumeLayout(false);
			this.splitForm.ResumeLayout(false);
			this.splitMessages.Panel1.ResumeLayout(false);
			this.splitMessages.Panel1.PerformLayout();
			this.splitMessages.Panel2.ResumeLayout(false);
			this.splitMessages.Panel2.PerformLayout();
			this.splitMessages.ResumeLayout(false);
			this.tbMessages.ResumeLayout(false);
			this.tbMessages.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton tbBtnPlay;
		private System.Windows.Forms.Label lblOnPause;
		private System.Windows.Forms.ToolStripButton tbButtonOpen;
		private System.Windows.Forms.ToolStripButton tbBtnRefresh;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.ToolStripButton tbBtnPause;
		private System.Windows.Forms.ToolStripButton tbBtnStop;
		private System.Windows.Forms.ToolStrip tbMessages;
		private System.Windows.Forms.SplitContainer splitMessages;
		private System.Windows.Forms.SplitContainer splitForm;
		private System.Windows.Forms.TextBox txtMessages;
		
		void MainFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
			if (this.inputDevice != null) {
				this.inputDevice.StopReceiving();
	            this.inputDevice.Close();
	           	this.inputDevice.RemoveAllEventHandlers();
			}
		}
		
		void TbBtnRefreshClick(object sender, System.EventArgs e) {
			if (this.inputDevice != null) {
				this.inputDevice.StopReceiving();
	            this.inputDevice.Close();
	            this.inputDevice.RemoveAllEventHandlers();
			}
			InitializeInputDevice();
		}
		
		void TbBtnStopClick(object sender, System.EventArgs e) {
			this.engine.StopAllSounds();
			if (this.currentVideo != null) {
				this.currentVideo.Stop();
				this.currentVideo.Dispose();
			}
			this.videoForm.Hide();
		}
		
		void TbBtnPlayClick(object sender, System.EventArgs e) {
			PlayMedia(this.test_sound);
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
		
		void TbButtonOpenClick(object sender, System.EventArgs e){
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
		
		private void Video_MouseEnter(object sender, System.EventArgs e) {
			Cursor.Hide();
		}
		
		private void Video_MouseLeave(object sender, System.EventArgs e) {
			Cursor.Show();
		}
	}
}
