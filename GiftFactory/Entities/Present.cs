using GiftFactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftFactory.Entities
{
    class Present : Toy
    {
        public Pen RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }
        public Present(Color box, Color ribbon)
        {
            BoxColor = new SolidBrush(box);
            RibbonColor = new Pen(ribbon);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 1, 1, Width, Height);
            g.DrawLine(RibbonColor, 25, 0, 25, 50);
            g.DrawLine(RibbonColor, 0, 25, 50, 25);
        }
    }

}
