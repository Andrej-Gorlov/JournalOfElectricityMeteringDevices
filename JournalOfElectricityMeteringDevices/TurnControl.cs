using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalOfElectricityMeteringDevices
{
    class TurnControl:System.Windows.Forms.Label
    {
        public void TurnLebel( System.Windows.Forms.Label label,int degree,string nameColor)
        {
            label.AutoSize = false;
            
            label.Paint += (s, a) =>
              {
                  a.Graphics.Clear(this.BackColor = Color.FromName(nameColor));
                  a.Graphics.RotateTransform(degree);
                  SizeF textSize = a.Graphics.MeasureString(label.Text, label.Font);
                  label.Width = (int)textSize.Height + 2;
                  label.Height = (int)textSize.Width + 2;
                  a.Graphics.TranslateTransform(-label.Height / 2, label.Width / 2);
                  a.Graphics.DrawString(label.Text, label.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
              };
        }
    }
}
