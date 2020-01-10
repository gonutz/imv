namespace imv
{
    // DoubleBufferedPanel avoids flickering when changing the background image.
    public class DoubleBufferedPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferedPanel() : base()
        {
            this.DoubleBuffered = true;
        }
    }

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
            this.components = new System.ComponentModel.Container();
            this.ImageBox = new DoubleBufferedPanel();
            this.MessageDisplay = new System.Windows.Forms.Label();
            this.FileWatchTimer = new System.Windows.Forms.Timer(this.components);
            this.ImageBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImageBox.Controls.Add(this.MessageDisplay);
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(0, 0);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(800, 450);
            this.ImageBox.TabIndex = 0;
            // 
            // MessageDisplay
            // 
            this.MessageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageDisplay.Location = new System.Drawing.Point(12, 9);
            this.MessageDisplay.Name = "MessageDisplay";
            this.MessageDisplay.Size = new System.Drawing.Size(776, 432);
            this.MessageDisplay.TabIndex = 0;
            this.MessageDisplay.Text = "Error Message";
            this.MessageDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileWatchTimer
            // 
            this.FileWatchTimer.Enabled = true;
            this.FileWatchTimer.Tick += new System.EventHandler(this.FileWatchTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImageBox);
            this.Name = "MainForm";
            this.Text = "Image Viewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ImageBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedPanel ImageBox;
        private System.Windows.Forms.Timer FileWatchTimer;
        private System.Windows.Forms.Label MessageDisplay;
    }
}

