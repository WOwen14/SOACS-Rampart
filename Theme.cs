using System.Drawing;

namespace SOACSRampart
{
    internal static class Theme
    {
        public static readonly Color Background = Color.FromArgb(12, 16, 17);
        public static readonly Color Panel = Color.FromArgb(18, 23, 25);
        public static readonly Color Panel2 = Color.FromArgb(24, 29, 31);
        public static readonly Color Header = Color.FromArgb(4, 5, 6);
        public static readonly Color Border = Color.FromArgb(54, 61, 64);
        public static readonly Color Gold = Color.FromArgb(181, 158, 72);
        public static readonly Color Text = Color.FromArgb(232, 235, 236);
        public static readonly Color Muted = Color.FromArgb(165, 172, 176);
        public static readonly Color Green = Color.FromArgb(91, 184, 72);
        public static readonly Font TitleFont = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        public static readonly Font NormalFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);
    }
}
