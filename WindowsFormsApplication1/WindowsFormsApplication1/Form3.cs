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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 haha = new Form6();
            Form6.beijing = 2;
            Form6.realtime = 1;
            this.Hide();
            haha.Show(this);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 hehe = new Form6();
            Form6.beijing = 3;
            Form6.realtime = 1;
            this.Hide();
            hehe.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)(this.Owner);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 hihi = new Form6();
            this.Hide();
            hihi.Show();
        }
    }
}
