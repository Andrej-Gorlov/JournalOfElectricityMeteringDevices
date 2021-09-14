using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
