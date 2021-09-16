using System.Drawing;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class BackgroundColor
    {
        public string colorName { get; set; }
        public void AskColor(Control control)
        {
            control.Paint += (s, a) =>
            {
                ControlPaint.DrawBorder(a.Graphics, control.ClientRectangle,
                Color.FromName(colorName), ButtonBorderStyle.Solid);
            };
        }
    }
}
