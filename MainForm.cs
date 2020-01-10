using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace imv
{
    public partial class MainForm : Form
    {
        private List<string> ImagePaths = new List<string>();
        // ImageIndex is the index into ImagePaths of the currently displayed image.
        private int ImageIndex;
        // LastModTime holds the time of last modification for the currently
        // displayed image. We track it to update our image if it changes on disk.
        private DateTime LastModTime;
        // OldBorderStyle and WindowOffset are for restoring the original window
        // when toggling fullscreen mode.
        private FormBorderStyle OldBorderStyle;
        private Point WindowOffset;


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
            // Escape closes the program.
            if (e.KeyCode == Keys.Escape)
                Close();

            // F1 shows the help.
            if (e.KeyCode == Keys.F1)
            {
                string helpText = @"Keyboard shortcuts:

Left/Right - go to previous/next image
1 - display image at original size
F - scale image to fit into current window size
F11 - toggle fullscreen mode (removes window borders)
Esc - close the program
F1 - show this help";
                MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Left/Right move the the previous/next image.
            if (e.KeyCode == Keys.Left)
                SetImageIndex(ImageIndex - 1);
            if (e.KeyCode == Keys.Right)
                SetImageIndex(ImageIndex + 1);

            // F11 toggles fullscreen mode, it removes the borders around the window.
            if (e.KeyCode == Keys.F11)
                ToggleFullscreenMode();

            // Keys '1' and 'F' are for scaling
            // '1' makes the image appear at its actual size.
            // 'F' makes it fit the current image size, stretching it.
            if (e.KeyCode == Keys.D1)
            {
                if (WindowState == FormWindowState.Maximized)
                    ImageBox.BackgroundImageLayout = ImageLayout.Center;
                else
                {
                    ImageBox.BackgroundImageLayout = ImageLayout.Zoom;
                    ClientSize = ImageBox.BackgroundImage.Size;
                    WindowState = FormWindowState.Normal;
                }
            }
            if (e.KeyCode == Keys.F)
            {
                ImageBox.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void ToggleFullscreenMode()
        {
            SuspendLayout();
            if (IsInFullscreenMode())
                DisableFullscreen();
            else
                EnableFullscreen();
            ResumeLayout();
        }

        private bool IsInFullscreenMode()
        {
            return FormBorderStyle == FormBorderStyle.None;
        }

        private void DisableFullscreen()
        {
            FormBorderStyle = OldBorderStyle;
            if (WindowState != FormWindowState.Maximized)
            {
                Left -= WindowOffset.X;
                Top -= WindowOffset.Y;
            }
        }

        private void EnableFullscreen()
        {
            if (WindowState != FormWindowState.Maximized)
            {
                // Compute the offset to make the client rectangle stay at
                // the same screen position as before. Removing the border
                // will reduce the overall window size but we want the
                // image to appear at the same screen location as before.
                WindowOffset = PointToScreen(new Point(0, 0));
                WindowOffset.X -= Bounds.X;
                WindowOffset.Y -= Bounds.Y;
                Left += WindowOffset.X;
                Top += WindowOffset.Y;
            }

            // Remember the original border style to reset it again later.
            OldBorderStyle = FormBorderStyle;
            FormBorderStyle = FormBorderStyle.None;
        }
    }
}
