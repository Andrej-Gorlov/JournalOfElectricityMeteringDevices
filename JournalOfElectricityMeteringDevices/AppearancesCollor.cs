using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalOfElectricityMeteringDevices
{
    class AppearancesCollor
    {
        public async void BackColorAppearances(System.Windows.Forms.Control control, byte[] initial , byte []final,
            byte rValue = 0, byte gValue = 0, byte bValue = 0,int delay = 0)
        {
            await Task.Delay(200);
            control.Visible = true;
            for (byte r = initial[0], g = initial[1], b = initial[2];
                r <= final[0] & g <= final[1] & b <= final[2];
                r += rValue, g += gValue, b += bValue, await Task.Delay(delay))
            {
                control.BackColor = Color.FromArgb(r, g, b);
            }
            control.BackColor = Color.FromArgb(final[0], final[1], final[2]);
        }
        public async void ForeColorAppearances(System.Windows.Forms.Control control, byte[] initial, byte[] final,
             byte rValue = 0, byte gValue = 0, byte bValue = 0, int delay =0)
        {
            await Task.Delay(250);
            control.Visible = true;
            for (byte r = initial[0], g = initial[1], b = initial[2];
                r >= final[0]+3 && g >= final[1]+3 && b >= final[2]+3;
                r -= rValue, g -= gValue, b -= bValue, await Task.Delay(delay))
            {
                control.ForeColor = Color.FromArgb(r, g, b);

            }
            control.ForeColor = Color.FromArgb(final[0], final[1], final[2]);
        }
    }
}
