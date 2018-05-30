using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public class MoveIndex
    {
        public MoveIndex(Label label , int index, Point location, int type)
        {
            this.lbl = label;
            this.Index = index;
            this.Location = location;
            this.Type = type;
        }
        public Label lbl { get; set; }
        public int Index { get; set; }
        public Point Location { get; set; }
        public int Type { get; set; }
        public override string ToString()
        {
            return lbl.Name;
        }
    }
}
