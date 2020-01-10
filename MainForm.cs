using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace imv
{
    public partial class MainForm : Form
    {
        // ImagePaths is a list of all images that the user wants to display.
        // ImageIndex is the index of the image that is currently displayed.
        private List<string> ImagePaths = new List<string>();
        private int ImageIndex;

        // LastModTime holds the time of last modification for the currently
        // displayed image. We track it to update our image if it changes on disk.
        private DateTime LastModTime;

        // OriginalBorderStyle, WasMaximized and BoundsBeforeMaximizing are for
        // restoring the original window when toggling fullscreen mode.
        private FormBorderStyle OriginalBorderStyle;
        private bool WasMaximized;
        private Rectangle BoundsBeforeMaximizing;

        // WindowMoveSpeed and LastWindowMove are for accelerated movement of the
        // window if the user keeps holding a move key down for some time.
        private int WindowMoveSpeed;
        private DateTime LastWindowMove;

        public MainForm()
        {
            InitializeComponent();

            var args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
                ImagePaths.Add(args[i]);

            SetImageIndex(0);
        }

        private void FileWatchTimer_Tick(object sender, EventArgs e)
        {
            if (ImagePaths.Count > 0)
            {
                try
                {
                    var modTime = File.GetLastWriteTime(ImagePaths[ImageIndex]);
                    // Reload the current image if it was changed on disk.
                    if (modTime > LastModTime)
                        SetImageIndex(ImageIndex);
                }
                catch
                {
                }
            }
        }

        private void SetImageIndex(int newIndex)
        {
            HideError();

            if (ImagePaths.Count == 0)
                ShowError("No image selected.");
            else
            {
                // Make the first image come right after the last image and vice versa.
                ImageIndex = newIndex;
                if (ImageIndex < 0)
                    ImageIndex += ImagePaths.Count;
                if (ImageIndex >= ImagePaths.Count)
                    ImageIndex -= ImagePaths.Count;

                var path = ImagePaths[ImageIndex];
                try
                {
                    this.Text = path;
                    // Load the image and dispose it so we do not keep an open file reference.
                    // If we did, the user could not make changes to the image while displaying it here.
                    using (var temp = new Bitmap(path))
                        ImageBox.BackgroundImage = new Bitmap(temp);
                    LastModTime = File.GetLastWriteTime(path);
                }
                catch
                {
                    ShowError("Image cannot be read.");
                }
            }
        }

        private void HideError()
        {
            MessageDisplay.Visible = false;
        }

        private void ShowError(string msg)
        {
            ImageBox.BackgroundImage = null;
            MessageDisplay.Text = msg;
            MessageDisplay.Visible = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Some keys cannot be set as shortcuts in Visual Studio
            // so we handle them manually and call the respective menu items ourselves.
            if (e.KeyCode == Keys.Escape)
                ExitMenu.PerformClick();
            if (e.KeyCode == Keys.Left)
                PreviousImageMenu.PerformClick();
            if (e.KeyCode == Keys.Right)
                NextImageMenu.PerformClick();
            if (e.KeyCode == Keys.D1)
                OriginalImageSizeMenu.PerformClick();
            if (e.KeyCode == Keys.F)
                FitImageToWindowMenu.PerformClick();
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviousMenu_Click(object sender, EventArgs e)
        {
            SetImageIndex(ImageIndex - 1);
        }

        private void NextMenu_Click(object sender, EventArgs e)
        {
            SetImageIndex(ImageIndex + 1);
        }

        private void ToggleFullscreenMenu_Click(object sender, EventArgs e)
        {
            if (IsInFullscreenMode())
                DisableFullscreen();
            else
                EnableFullscreen();
        }

        private bool IsInFullscreenMode()
        {
            return !MainMenu.Visible;
        }

        private void DisableFullscreen()
        {
            var oldImageBounds = RectangleToScreen(ImageBox.Bounds);
            MainMenu.Visible = true;
            FormBorderStyle = OriginalBorderStyle;

            if (WasMaximized)
            {
                WindowState = FormWindowState.Maximized;
                this.Bounds = BoundsBeforeMaximizing;
            }
            else
            {
                var newImageBounds = RectangleToScreen(ImageBox.Bounds);
                this.Bounds = new Rectangle(
                    Left + oldImageBounds.X - newImageBounds.X,
                    Top + oldImageBounds.Y - newImageBounds.Y,
                    Width + oldImageBounds.Width - newImageBounds.Width,
                    Height + oldImageBounds.Height - newImageBounds.Height
                );
            }
        }

        private void EnableFullscreen()
        {
            var oldImageBounds = RectangleToScreen(ImageBox.Bounds);
            WasMaximized = WindowState == FormWindowState.Maximized;

            MainMenu.Visible = false;
            OriginalBorderStyle = FormBorderStyle;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;

            if (WasMaximized)
                this.Bounds = Screen.FromControl(this).WorkingArea;
            else
                Bounds = oldImageBounds;
        }

        private void OriginalImageSizeMenu_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                ImageBox.BackgroundImageLayout = ImageLayout.Center;
            else
            {
                ImageBox.BackgroundImageLayout = ImageLayout.Zoom;
                if (ImageBox.BackgroundImage != null)
                {
                    ClientSize = ImageBox.BackgroundImage.Size;
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void FitImageToWindowMenu_Click(object sender, EventArgs e)
        {
            ImageBox.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void HelpMenu_Click(object sender, EventArgs e)
        {
            string helpText = @"Keyboard shortcuts:

Left/Right - go to previous/next image
1 - display image at original size
F - scale image to fit into current window size
F11 - toggle fullscreen mode (removes window borders)
Ctrl+Left/Right/Up/Down - move the window
Esc - close the program
F1 - show this help";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MoveWindowLeftMenu_Click(object sender, EventArgs e)
        {
            MoveWindow(-1, 0);
        }

        private void MoveWindowRightMenu_Click(object sender, EventArgs e)
        {
            MoveWindow(1, 0);
        }

        private void MoveWindowDownMenu_Click(object sender, EventArgs e)
        {
            MoveWindow(0, 1);
        }

        private void OveWindowUpMenu_Click(object sender, EventArgs e)
        {
            MoveWindow(0, -1);
        }

        private void MoveWindow(int dx, int dy)
        {
            var now = DateTime.Now;
            var dt = now - LastWindowMove;
            LastWindowMove = now;

            if (dt.Milliseconds < 50)
                WindowMoveSpeed++;
            else
                WindowMoveSpeed = 1;

            const int MaxSpeed = 500;
            if (WindowMoveSpeed < 1)
                WindowMoveSpeed = 1;
            if (WindowMoveSpeed > MaxSpeed)
                WindowMoveSpeed = MaxSpeed;

            Left += dx * WindowMoveSpeed;
            Top += dy * WindowMoveSpeed;
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                BoundsBeforeMaximizing = this.Bounds;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            BoundsBeforeMaximizing = this.Bounds;
        }
    }
}
