using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solution_Ball
{
    public partial class Form1 : Form
    {
        Vector r0, v0, g, r;
        double t;
        Point start;
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += timer1.Interval/1000.0;
            r = r0 + v0 * t + g * t * t / 2;
            ball.Location = new Point((int)r.X, (int)r.Y);
            if (ball.Top+ball.Height>pictureBox1.Top)
            {
                Vector v = v0 + g * t;
                v0 = v.Mirror(new Vector(1, 0)) * 0.8;
                t = 0;
                r0 = r;
                if(v0.SqAbs<100)
                timer1.Stop();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r0 = new Vector(ball.Location.X,ball.Location.Y);
            v0 = new Vector(trackBar1.Value, -trackBar2.Value);
            g = new Vector(0, 980);
            t = 0;
            start = ball.Location;
            timer1.Start();
        }
    }
}
