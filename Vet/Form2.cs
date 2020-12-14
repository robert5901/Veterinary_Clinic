using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ветклиника
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            Form5.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 Form8 = new Form8();
            Form8.ShowDialog(this);
        }
    }
}
