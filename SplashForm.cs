using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SOACSRampart
{
    public class SplashForm : Form
    {
        private Timer timer;
        private ProgressBar progress;
        private int ticks;
        public SplashForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(680, 420);
            BackColor = Theme.Header;
            var border = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Header, Padding = new Padding(2) };
            Controls.Add(border);
            var body = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Background, Padding = new Padding(28) };
            border.Controls.Add(body);
            var logo = new PictureBox { Size = new Size(150,150), SizeMode = PictureBoxSizeMode.Zoom, Location = new Point((Width-150)/2, 30) };
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "RampartLogo.png");
            if (File.Exists(path)) logo.Image = Image.FromFile(path);
            body.Controls.Add(logo);
            var title = new Label { Text="SOACS RAMPART", ForeColor=Theme.Gold, Font=new Font("Segoe UI Semibold", 30, FontStyle.Bold), AutoSize=false, TextAlign=ContentAlignment.MiddleCenter, Location=new Point(0,190), Size=new Size(624,55)};
            body.Controls.Add(title);
            var sub = new Label { Text="NETWORK ENGINEERING & COMPLIANCE SUITE", ForeColor=Theme.Muted, Font=Theme.HeaderFont, AutoSize=false, TextAlign=ContentAlignment.MiddleCenter, Location=new Point(0,245), Size=new Size(624,30)};
            body.Controls.Add(sub);
            var tag = new Label { Text="BUILD  •  VALIDATE  •  HARDEN  •  DEPLOY", ForeColor=Theme.Gold, Font=Theme.HeaderFont, AutoSize=false, TextAlign=ContentAlignment.MiddleCenter, Location=new Point(0,292), Size=new Size(624,30)};
            body.Controls.Add(tag);
            progress = new ProgressBar { Location=new Point(170,345), Size=new Size(285,14), Minimum=0, Maximum=100, Value=0 };
            body.Controls.Add(progress);
            var copy = new Label { Text="© 2025 SOACS", ForeColor=Theme.Muted, Font=Theme.SmallFont, AutoSize=false, TextAlign=ContentAlignment.MiddleCenter, Location=new Point(0,365), Size=new Size(624,22)};
            body.Controls.Add(copy);
            timer = new Timer { Interval = 35 };
            timer.Tick += (s,e)=> { ticks += 4; progress.Value = Math.Min(100, ticks); if (ticks >= 100) { timer.Stop(); DialogResult = DialogResult.OK; Close(); } };
            Shown += (s,e)=> timer.Start();
        }
    }
}
