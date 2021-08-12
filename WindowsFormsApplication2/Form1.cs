using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        static public int number_process;
        static public string scheduling_algorithm;
        public Form1()
        {
            InitializeComponent();
            number_process = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void next_info_Click(object sender, EventArgs e)
        {
            //number_process = metroComboBox1.SelectedItem.ToString();
            scheduling_algorithm = algorithm.SelectedItem.ToString(); 
            Form2 x = new Form2();
            x.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (number_process < 60)
            {
                number_process++;
                label4.Text = number_process.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (number_process > 2)
            {
                number_process--;
                label4.Text = number_process.ToString();
            }

        }
    }
}
