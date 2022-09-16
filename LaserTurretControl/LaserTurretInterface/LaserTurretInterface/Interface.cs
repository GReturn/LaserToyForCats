using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LaserTurretInterface
{
    public partial class LaserTurretInterface : Form
    {
        // Adds latency in order not to overload the controls with data
        public Stopwatch Watch { get; set; }

        public LaserTurretInterface()
        {
            InitializeComponent();
        }

        private void LaserTurretInterface_Load(object sender, EventArgs e)
        {
            Watch = Stopwatch.StartNew();
            SerialPort.Open();
        }

        private void LaserTurretInterface_MouseMove(object sender, MouseEventArgs e)
        {
            WriteToPort(new Point(e.X, e.Y));
        }
        public void WriteToPort(Point coordinates)
        {
            if (Watch.ElapsedMilliseconds > 15)
            {
                Watch = Stopwatch.StartNew();

                SerialPort.Write(String.Format("X{0}Y{1}",
                180 - coordinates.X / (Size.Width / 180),
                coordinates.Y / (Size.Height / 180)));
            }
        }
    }
}
