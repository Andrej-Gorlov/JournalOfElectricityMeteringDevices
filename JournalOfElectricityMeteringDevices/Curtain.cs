﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalOfElectricityMeteringDevices
{
    class Curtain
    {
        bool expectation;
        public async void OpenUp(System.Windows.Forms.DataGridView DGV, System.Windows.Forms.Panel panel)
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

        public async void CloseDown(System.Windows.Forms.DataGridView DGV, System.Windows.Forms.Panel panel)
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
    }
}