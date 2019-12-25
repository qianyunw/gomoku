using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Form6 haha = new Form6();
            //this.Hide();
            //haha.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 haha = new Form3();
            haha.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form7 hiahia = new Form7();
            hiahia.Show();

        }
    }
}
