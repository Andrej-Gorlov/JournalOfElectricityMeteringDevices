using System.Drawing;
using System.Windows.Forms;

namespace JournalOfElectricityMeteringDevices
{
    class ButtonBoundaryChanges
    {
        public void Butotn(Button button, byte i, string color)
        {
            button.FlatAppearance.BorderSize = i;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.FromName(color);
        }
    }
}
