using System.Drawing;
using System.Windows.Forms;

namespace SOACSRampart.Pages
{
    public class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            BackColor = Theme.Background;
            Padding = new Padding(0);
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 4, BackColor = Theme.Background };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 132));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
            Controls.Add(root);

            var title = new Label { Dock = DockStyle.Fill, Text = "Dashboard", ForeColor = Theme.Text, Font = new Font("Segoe UI Semibold", 21, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };
            root.Controls.Add(title, 0, 0);

            var cards = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 5, RowCount = 1, BackColor = Theme.Background, Padding = new Padding(0, 0, 0, 14) };
            for (int i = 0; i < 5; i++) cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            root.Controls.Add(cards, 0, 1);
            cards.Controls.Add(Card("DEVICES", "0", "Managed devices"), 0, 0);
            cards.Controls.Add(Card("SYNTAX", "READY", "No config loaded"), 1, 0);
            cards.Controls.Add(Card("STIG", "READY", "Checklist not loaded"), 2, 0);
            cards.Controls.Add(Card("DEPLOYMENT", "STANDBY", "No pending jobs"), 3, 0);
            cards.Controls.Add(Card("BACKUPS", "0", "Current backups"), 4, 0);

            var lower = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1, BackColor = Theme.Background };
            lower.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32));
            lower.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            lower.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            root.Controls.Add(lower, 0, 2);
            lower.Controls.Add(ListPanel("RECENT DEVICES", new[] { "No devices loaded", "Add a device in the Devices page", "Import running-config", "Generate deployment package" }), 0, 0);
            lower.Controls.Add(ListPanel("CONFIGURATION ACTIVITY", new[] { "Rampart foundation loaded", "UI shell initialized", "No validation run yet", "No deployment run yet" }), 1, 0);
            lower.Controls.Add(ListPanel("DEPLOYMENT READINESS", new[] { "Syntax: Not checked", "STIG: Not checked", "Security: Review required", "Overall: Standby" }), 2, 0);
        }

        private Control Card(string heading, string value, string caption)
        {
            var p = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Panel2, Margin = new Padding(0, 0, 12, 0), Padding = new Padding(18) };
            p.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Theme.Border, ButtonBorderStyle.Solid);
            p.Controls.Add(new Label { Text = heading, Dock = DockStyle.Top, Height = 25, ForeColor = Theme.Text, Font = Theme.SmallFont, TextAlign = ContentAlignment.MiddleLeft });
            p.Controls.Add(new Label { Text = value, Dock = DockStyle.Top, Height = 45, ForeColor = Theme.Green, Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft });
            p.Controls.Add(new Label { Text = caption, Dock = DockStyle.Fill, ForeColor = Theme.Muted, Font = Theme.SmallFont, TextAlign = ContentAlignment.TopLeft });
            return p;
        }

        private Control ListPanel(string heading, string[] items)
        {
            var p = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Panel, Margin = new Padding(0, 0, 12, 0), Padding = new Padding(18) };
            p.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Theme.Border, ButtonBorderStyle.Solid);
            p.Controls.Add(new Label { Text = heading, Dock = DockStyle.Top, Height = 34, ForeColor = Theme.Text, Font = Theme.HeaderFont });
            var flow = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, BackColor = Theme.Panel };
            foreach (var item in items) flow.Controls.Add(new Label { Text = "●  " + item, Width = 330, Height = 34, ForeColor = Theme.Muted, Font = Theme.NormalFont, TextAlign = ContentAlignment.MiddleLeft });
            p.Controls.Add(flow);
            flow.BringToFront();
            return p;
        }
    }
}
