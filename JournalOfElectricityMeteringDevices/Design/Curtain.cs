using System.Drawing;
using System.Threading.Tasks;

namespace JournalOfElectricityMeteringDevices
{
    class Curtain
    {
        bool expectation;
        public async void OpenUp(System.Windows.Forms.Control DGV, System.Windows.Forms.Control panel)
        {
            while (!expectation && DGV.Location.Y < panel.Location.Y)
            {
                expectation = true;
                await Task.Delay(1);
                panel.Height += DGV.Location.Y / 3;
                panel.Location = new Point(panel.Location.X, panel.Location.Y - DGV.Location.Y / 3);
                expectation = false;
            }
        }
        public async void CloseDown(System.Windows.Forms.Control DGV, System.Windows.Forms.Control panel)
        {
            while (!expectation && 50 < panel.Height)
            {
                expectation = true;
                await Task.Delay(1);
                panel.Location = new Point(panel.Location.X, panel.Location.Y + DGV.Location.Y / 3);
                panel.Height -= DGV.Location.Y / 3;
                expectation = false;
            }
        }
        public async void OpenLeft(System.Windows.Forms.Control panel, int locationX,byte openingSpeed,int delay=1)
        {
            while (!expectation && locationX > panel.Location.X)
            {
                expectation = true;
                await Task.Delay(delay);
                panel.Location = new Point((panel.Location.X+(panel.Location.X/ openingSpeed))/ openingSpeed, panel.Location.Y);
                expectation = false;
            }
        }
        public async void CloseRight(System.Windows.Forms.Control panel,int locationX , byte closingSpeed, int delay = 1)
        {
            while (!expectation && locationX < panel.Location.X)
            {
                expectation = true;
                await Task.Delay(delay);
                panel.Location = new Point(panel.Location.X - closingSpeed, panel.Location.Y);
                expectation = false;
            }
        }
    }
}
