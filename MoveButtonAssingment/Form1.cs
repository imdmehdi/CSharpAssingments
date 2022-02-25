using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveButtonAssingment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void PerformMovement(int x, int y, bool fromTopLeft);

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var xAxis=this.button1.Location.X;
            var yAxis= this.button1.Location.X;

            PerformMovement performMovement = new PerformMovement(MoveElement);
            performMovement(xAxis,yAxis,false);
        }
        private  void MoveElement(int xAxis, int yAxis, bool fromTopLeft)
        {
            try
            {
                var movementNeeded = 0;
                if (this.listBox1.SelectedItem == null) ;
                else if(!fromTopLeft)
                     movementNeeded = Convert.ToInt32(this.listBox1.SelectedItem.ToString());
                this.button1.Location = new Point(xAxis + movementNeeded, yAxis + movementNeeded);
            }
            catch (Exception ex )
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PerformMovement performMovement = new PerformMovement(MoveElement);
            performMovement(0,0, true);
        }
    }
}
