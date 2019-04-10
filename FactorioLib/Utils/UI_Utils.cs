using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorioLib.Utils
{
    public static class UI_Utils
    {
        //Mutated from example ==> https://stackoverflow.com/a/20042058
        public static void DrawGroupBox(GroupBox box, Graphics g, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(box.ForeColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                //Lazy hack solution
                g.Clear(SystemColors.Control);

                //g.Clear(box.BackColor); // Clear text and border
                //g.Clear(box.Parent.BackColor);

                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0); // Draw text
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height)); //Left                
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height)); //Right                
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height)); //Bottom                
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y)); //Top1                
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y)); //Top2
                
                //Prevent memory leak (Must dispose GDI items)
                textBrush.Dispose();
                borderBrush.Dispose();
                borderPen.Dispose();
            }
        }
    }
}