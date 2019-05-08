namespace MidiForm
{
    partial class LoadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panVideo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panVideo
            // 
            this.panVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panVideo.BackColor = System.Drawing.Color.Black;
            this.panVideo.Location = new System.Drawing.Point(0, 0);
            this.panVideo.Name = "panVideo";
            this.panVideo.Size = new System.Drawing.Size(160, 90);
            this.panVideo.TabIndex = 1;
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.panVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panVideo;

    }
}