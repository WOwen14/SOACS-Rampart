using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SOACSRampart.Pages;

namespace SOACSRampart
{
    public class MainForm : Form
    {
        private Panel headerPanel;
        private Panel navPanel;
        private Panel contentPanel;
        private Panel statusPanel;
        private Panel bodyPanel;
        private Label statusClock;
        private readonly Dictionary<string, UserControl> pages = new Dictionary<string, UserControl>();
        private Timer clockTimer;

        public MainForm()
        {
            Text = "SOACS Rampart v1.0 Alpha Foundation";
            StartPosition = FormStartPosition.CenterScreen;
            AutoScaleMode = AutoScaleMode.Dpi;
            MinimumSize = new Size(1100, 680);
            BackColor = Theme.Background;
            Font = Theme.NormalFont;

            SetSafeStartupBounds();
            BuildShell();
            BuildPages();
            ShowPage("Dashboard");
        }

        private void SetSafeStartupBounds()
        {
            Rectangle work = Screen.PrimaryScreen.WorkingArea;
            int width = Math.Min(1360, Math.Max(1100, work.Width - 80));
            int height = Math.Min(780, Math.Max(680, work.Height - 80));
            Size = new Size(width, height);
            Location = new Point(work.Left + (work.Width - width) / 2, work.Top + (work.Height - height) / 2);
        }

        private void BuildShell()
        {
            SuspendLayout();

            // Top header. This is always above the work area and never overlaps content.
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 78,
                BackColor = Theme.Header,
                Padding = new Padding(14, 8, 14, 8)
            };
            Controls.Add(headerPanel);
            BuildHeader();

            // Bottom status bar. Kept inside the Windows working area by SetSafeStartupBounds().
            statusPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Theme.Header,
                Padding = new Padding(12, 0, 12, 0)
            };
            Controls.Add(statusPanel);
            BuildStatusBar();

            // Body panel owns both nav and content. This prevents the left nav/header from ever covering page controls.
            bodyPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Background,
                Padding = new Padding(0)
            };
            Controls.Add(bodyPanel);
            bodyPanel.BringToFront();
            headerPanel.BringToFront();
            statusPanel.BringToFront();

            navPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 190,
                BackColor = Theme.Panel,
                Padding = new Padding(0, 10, 0, 0)
            };
            bodyPanel.Controls.Add(navPanel);
            BuildNavigation();

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Background,
                Padding = new Padding(18)
            };
            bodyPanel.Controls.Add(contentPanel);
            contentPanel.BringToFront();

            ResumeLayout(true);
        }

        private void BuildHeader()
        {
            var logo = new PictureBox
            {
                Dock = DockStyle.Left,
                Width = 64,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Theme.Header
            };
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "RampartLogo.png");
            if (File.Exists(path)) logo.Image = Image.FromFile(path);
            headerPanel.Controls.Add(logo);

            var titleBlock = new Panel
            {
                Dock = DockStyle.Left,
                Width = 480,
                BackColor = Theme.Header,
                Padding = new Padding(12, 0, 0, 0)
            };
            headerPanel.Controls.Add(titleBlock);

            var title = new Label
            {
                Dock = DockStyle.Top,
                Height = 38,
                Text = "SOACS RAMPART",
                ForeColor = Theme.Gold,
                Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold),
                TextAlign = ContentAlignment.BottomLeft
            };
            var subtitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                Text = "NETWORK ENGINEERING & COMPLIANCE SUITE",
                ForeColor = Theme.Muted,
                Font = Theme.SmallFont,
                TextAlign = ContentAlignment.TopLeft
            };
            titleBlock.Controls.Add(subtitle);
            titleBlock.Controls.Add(title);

            var conn = new Label
            {
                Dock = DockStyle.Right,
                Width = 170,
                Text = "● STANDBY\r\n127.0.0.1",
                ForeColor = Theme.Muted,
                Font = Theme.SmallFont,
                TextAlign = ContentAlignment.MiddleRight
            };
            headerPanel.Controls.Add(conn);

            var tagline = new Label
            {
                Dock = DockStyle.Fill,
                Text = "BUILD  •  VALIDATE  •  HARDEN  •  DEPLOY",
                ForeColor = Theme.Gold,
                Font = Theme.HeaderFont,
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(tagline);
        }

        private void BuildStatusBar()
        {
            AddStatusLabel("● READY", 12, 120, Theme.Green);
            AddStatusLabel("DATABASE: LOCAL", 145, 170, Theme.Muted);
            AddStatusLabel("CONFIG REPO: LOCAL", 330, 190, Theme.Muted);
            AddStatusLabel("SSH: DISCONNECTED", 535, 190, Theme.Muted);

            statusClock = new Label
            {
                Dock = DockStyle.Right,
                Width = 185,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Theme.Muted,
                Font = Theme.SmallFont
            };
            statusPanel.Controls.Add(statusClock);

            clockTimer = new Timer { Interval = 1000 };
            clockTimer.Tick += (s, e) => statusClock.Text = DateTime.Now.ToString("M/d/yyyy  HH:mm:ss");
            clockTimer.Start();
            statusClock.Text = DateTime.Now.ToString("M/d/yyyy  HH:mm:ss");
        }

        private void BuildNavigation()
        {
            var version = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 44,
                Text = "SOACS Rampart v1.0.0 Alpha\r\n© 2025 SOACS",
                ForeColor = Theme.Muted,
                Font = Theme.SmallFont,
                TextAlign = ContentAlignment.MiddleCenter
            };
            navPanel.Controls.Add(version);

            string[] names =
            {
                "Dashboard", "Devices", "Templates", "Interfaces", "Routing", "Security",
                "STIG Compliance", "Deployment", "Reports", "Settings", "About"
            };

            // Add from bottom to top when using DockStyle.Top so the final visual order is correct.
            for (int i = names.Length - 1; i >= 0; i--)
                AddNavButton(names[i]);
        }

        private void AddStatusLabel(string text, int left, int width, Color color)
        {
            statusPanel.Controls.Add(new Label
            {
                Text = text,
                Left = left,
                Top = 0,
                Height = statusPanel.Height,
                Width = width,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = color,
                Font = Theme.SmallFont
            });
        }

        private void AddNavButton(string name)
        {
            var b = new Button
            {
                Text = name,
                Tag = name,
                Height = 48,
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                ForeColor = Theme.Text,
                BackColor = Theme.Panel,
                Font = Theme.NormalFont
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Theme.Panel2;
            b.FlatAppearance.MouseDownBackColor = Theme.Border;
            b.Click += (s, e) => ShowPage((string)((Button)s).Tag);
            navPanel.Controls.Add(b);
        }

        private void BuildPages()
        {
            pages["Dashboard"] = new DashboardPage();
            pages["Devices"] = new PlaceholderPage("Devices", "Device inventory, model detection, running config import, and backup status will live here.");
            pages["Templates"] = new PlaceholderPage("Templates", "Template library, variables, approved baselines, and generated configuration preview.");
            pages["Interfaces"] = new PlaceholderPage("Interfaces", "Auto-detected interfaces with per-port Layer 2 / Layer 3 configuration cards.");
            pages["Routing"] = new PlaceholderPage("Routing", "Static routes, OSPF, EIGRP, BGP, VRF, and route validation.");
            pages["Security"] = new PlaceholderPage("Security", "AAA, SSH, SNMP, NTP, logging, banners, ACLs, certificates, and hardening controls.");
            pages["STIG Compliance"] = new PlaceholderPage("STIG Compliance", "Import CKL/XCCDF/XML/CSV, run mapped pre-checks, flag manual review, and export reports.");
            pages["Deployment"] = new PlaceholderPage("Deployment", "Backup, diff, push config, verify, and rollback workflow.");
            pages["Reports"] = new PlaceholderPage("Reports", "Deployment reports, STIG reports, engineering packages, and change records.");
            pages["Settings"] = new PlaceholderPage("Settings", "Application settings, repository paths, connection methods, and visual preferences.");
            pages["About"] = new PlaceholderPage("About", "SOACS Rampart: Build • Validate • Harden • Deploy.");
        }

        private void ShowPage(string name)
        {
            if (contentPanel == null) return;
            contentPanel.Controls.Clear();
            UserControl page = pages.ContainsKey(name) ? pages[name] : pages["Dashboard"];
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }
    }
}
