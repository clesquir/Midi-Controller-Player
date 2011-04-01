/*
 * Created by SharpDevelop.
 * User: cedric
 * Date: 11/01/2011
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MidiForm
{
	partial class VideoForm
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
			this.panVideo = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panVideo
			// 
			this.panVideo.Location = new System.Drawing.Point(0, 0);
			this.panVideo.Name = "panVideo";
			this.panVideo.Size = new System.Drawing.Size(494, 281);
			this.panVideo.TabIndex = 0;
			// 
			// VideoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(761, 487);
			this.Controls.Add(this.panVideo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "VideoForm";
			this.Text = "Video";
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Panel panVideo;
	}
}
