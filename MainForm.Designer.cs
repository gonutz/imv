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
            this.FileWatchTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviousImageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NextImageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleFullscreenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginalImageSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FitImageToWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveWindowLeftMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveWindowRightMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveWindowDownMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.oveWindowUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageBox = new imv.DoubleBufferedPanel();
            this.MessageDisplay = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.ImageBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileWatchTimer
            // 
            this.FileWatchTimer.Enabled = true;
            this.FileWatchTimer.Tick += new System.EventHandler(this.FileWatchTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.ImageMenu,
            this.ViewMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.ShortcutKeyDisplayString = "Esc";
            this.ExitMenu.Size = new System.Drawing.Size(117, 22);
            this.ExitMenu.Text = "E&xit";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // ImageMenu
            // 
            this.ImageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreviousImageMenu,
            this.NextImageMenu});
            this.ImageMenu.Name = "ImageMenu";
            this.ImageMenu.Size = new System.Drawing.Size(52, 20);
            this.ImageMenu.Text = "&Image";
            // 
            // PreviousImageMenu
            // 
            this.PreviousImageMenu.Name = "PreviousImageMenu";
            this.PreviousImageMenu.ShortcutKeyDisplayString = "Left";
            this.PreviousImageMenu.Size = new System.Drawing.Size(146, 22);
            this.PreviousImageMenu.Text = "&Previous";
            this.PreviousImageMenu.Click += new System.EventHandler(this.PreviousMenu_Click);
            // 
            // NextImageMenu
            // 
            this.NextImageMenu.Name = "NextImageMenu";
            this.NextImageMenu.ShortcutKeyDisplayString = "Right";
            this.NextImageMenu.Size = new System.Drawing.Size(146, 22);
            this.NextImageMenu.Text = "&Next";
            this.NextImageMenu.Click += new System.EventHandler(this.NextMenu_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleFullscreenMenu,
            this.OriginalImageSizeMenu,
            this.FitImageToWindowMenu,
            this.MoveWindowLeftMenu,
            this.MoveWindowRightMenu,
            this.MoveWindowDownMenu,
            this.oveWindowUpMenu});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ToggleFullscreenMenu
            // 
            this.ToggleFullscreenMenu.Name = "ToggleFullscreenMenu";
            this.ToggleFullscreenMenu.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.ToggleFullscreenMenu.Size = new System.Drawing.Size(250, 22);
            this.ToggleFullscreenMenu.Text = "&Toggle Fullscreen";
            this.ToggleFullscreenMenu.Click += new System.EventHandler(this.ToggleFullscreenMenu_Click);
            // 
            // OriginalImageSizeMenu
            // 
            this.OriginalImageSizeMenu.Name = "OriginalImageSizeMenu";
            this.OriginalImageSizeMenu.ShortcutKeyDisplayString = "1";
            this.OriginalImageSizeMenu.Size = new System.Drawing.Size(250, 22);
            this.OriginalImageSizeMenu.Text = "&Original Image Size";
            this.OriginalImageSizeMenu.Click += new System.EventHandler(this.OriginalImageSizeMenu_Click);
            // 
            // FitImageToWindowMenu
            // 
            this.FitImageToWindowMenu.Name = "FitImageToWindowMenu";
            this.FitImageToWindowMenu.ShortcutKeyDisplayString = "F";
            this.FitImageToWindowMenu.Size = new System.Drawing.Size(250, 22);
            this.FitImageToWindowMenu.Text = "&Fit Image to Window";
            this.FitImageToWindowMenu.Click += new System.EventHandler(this.FitImageToWindowMenu_Click);
            // 
            // MoveWindowLeftMenu
            // 
            this.MoveWindowLeftMenu.Name = "MoveWindowLeftMenu";
            this.MoveWindowLeftMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.MoveWindowLeftMenu.Size = new System.Drawing.Size(250, 22);
            this.MoveWindowLeftMenu.Text = "Move Window &Left";
            this.MoveWindowLeftMenu.Click += new System.EventHandler(this.MoveWindowLeftMenu_Click);
            // 
            // MoveWindowRightMenu
            // 
            this.MoveWindowRightMenu.Name = "MoveWindowRightMenu";
            this.MoveWindowRightMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.MoveWindowRightMenu.Size = new System.Drawing.Size(250, 22);
            this.MoveWindowRightMenu.Text = "Move Window &Right";
            this.MoveWindowRightMenu.Click += new System.EventHandler(this.MoveWindowRightMenu_Click);
            // 
            // MoveWindowDownMenu
            // 
            this.MoveWindowDownMenu.Name = "MoveWindowDownMenu";
            this.MoveWindowDownMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.MoveWindowDownMenu.Size = new System.Drawing.Size(250, 22);
            this.MoveWindowDownMenu.Text = "Move Window &Down";
            this.MoveWindowDownMenu.Click += new System.EventHandler(this.MoveWindowDownMenu_Click);
            // 
            // oveWindowUpMenu
            // 
            this.oveWindowUpMenu.Name = "oveWindowUpMenu";
            this.oveWindowUpMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.oveWindowUpMenu.Size = new System.Drawing.Size(250, 22);
            this.oveWindowUpMenu.Text = "Move Window &Up";
            this.oveWindowUpMenu.Click += new System.EventHandler(this.OveWindowUpMenu_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            this.HelpMenu.Click += new System.EventHandler(this.HelpMenu_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImageBox.Controls.Add(this.MessageDisplay);
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(0, 24);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(800, 426);
            this.ImageBox.TabIndex = 0;
            // 
            // MessageDisplay
            // 
            this.MessageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageDisplay.Location = new System.Drawing.Point(12, 9);
            this.MessageDisplay.Name = "MessageDisplay";
            this.MessageDisplay.Size = new System.Drawing.Size(776, 408);
            this.MessageDisplay.TabIndex = 0;
            this.MessageDisplay.Text = "Error Message";
            this.MessageDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Image Viewer";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ImageBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferedPanel ImageBox;
        private System.Windows.Forms.Timer FileWatchTimer;
        private System.Windows.Forms.Label MessageDisplay;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem ImageMenu;
        private System.Windows.Forms.ToolStripMenuItem PreviousImageMenu;
        private System.Windows.Forms.ToolStripMenuItem NextImageMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewMenu;
        private System.Windows.Forms.ToolStripMenuItem ToggleFullscreenMenu;
        private System.Windows.Forms.ToolStripMenuItem OriginalImageSizeMenu;
        private System.Windows.Forms.ToolStripMenuItem FitImageToWindowMenu;
        private System.Windows.Forms.ToolStripMenuItem MoveWindowLeftMenu;
        private System.Windows.Forms.ToolStripMenuItem MoveWindowRightMenu;
        private System.Windows.Forms.ToolStripMenuItem MoveWindowDownMenu;
        private System.Windows.Forms.ToolStripMenuItem oveWindowUpMenu;
    }
}

