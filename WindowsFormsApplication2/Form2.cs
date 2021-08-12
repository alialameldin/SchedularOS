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
    public partial class Form2 : Form
    {
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        public static NumericUpDown[] numericUpDown = new NumericUpDown[Form1.number_process];
        public static NumericUpDown[] numericUpDown2 = new NumericUpDown[Form1.number_process];
        public static NumericUpDown[] priority = new NumericUpDown[Form1.number_process];
        public static NumericUpDown qnum = new NumericUpDown();


        public Form2()
        {
            InitializeComponent();
            numericUpDown = new NumericUpDown[Form1.number_process];
            numericUpDown2 = new NumericUpDown[Form1.number_process];
            priority = new NumericUpDown[Form1.number_process];
            qnum = new NumericUpDown();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabControl2.SuspendLayout();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form2));

            MetroFramework.Controls.MetroTabPage[] metroTabPage = new MetroFramework.Controls.MetroTabPage[Convert.ToInt32(Form1.number_process)];
            if(Form1.scheduling_algorithm=="RoundRobin"){
                Panel p = new Panel();
                p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(178)))), ((int)(((byte)(151)))));
                p.Location = new System.Drawing.Point(325, 115);
                p.Name = "panel5";
                p.Size = new System.Drawing.Size(29, 75);
                p.TabIndex = 5;
                this.Controls.Add(p);
                Label q = new Label();
                q.AutoSize = true;
                q.BackColor = System.Drawing.Color.White;
                q.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                q.Location = new System.Drawing.Point(370, 133);
                q.Name = "label2";
                q.Size = new System.Drawing.Size(144, 38);
                q.TabIndex = 7;
                q.Text = "Enter time quantum 'q'";
                this.Controls.Add(q);
                qnum.Location = new System.Drawing.Point(400, 200);
                qnum.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
                qnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                qnum.Name = "numericUpDown1";
                qnum.Size = new System.Drawing.Size(237, 20);
                qnum.TabIndex = 3;
                qnum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                this.Controls.Add(qnum);
            }
            for (int i = 0; i < Form1.number_process; i++)
            {
                // numericUpDown1
                numericUpDown[i] = new System.Windows.Forms.NumericUpDown();
                numericUpDown2[i] = new System.Windows.Forms.NumericUpDown();
                numericUpDown[i].Location = new System.Drawing.Point(57, 110);
                numericUpDown[i].Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
                numericUpDown[i].Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                numericUpDown[i].Name = "numericUpDown1";
                numericUpDown[i].Size = new System.Drawing.Size(237, 20);
                numericUpDown[i].TabIndex = 3;
                numericUpDown[i].Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                //numeric control2
                numericUpDown2[i].Location = new System.Drawing.Point(57, 250);
                numericUpDown2[i].Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
                numericUpDown2[i].Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
                numericUpDown2[i].Name = "numericUpDown2";
                numericUpDown2[i].Size = new System.Drawing.Size(237, 20);
                numericUpDown2[i].TabIndex = 3;
                numericUpDown2[i].Value = new decimal(new int[] {
            0,
            0,
            0,
            0});


                metroTabPage[i] = new MetroFramework.Controls.MetroTabPage();
                metroTabPage[i].HorizontalScrollbarBarColor = true;
                metroTabPage[i].HorizontalScrollbarHighlightOnWheel = false;
                metroTabPage[i].HorizontalScrollbarSize = 10;
                metroTabPage[i].Location = new System.Drawing.Point(4, 38);
                metroTabPage[i].Name = "metroTabPage"+i.ToString();
                metroTabPage[i].Size = new System.Drawing.Size(706, 298);
                metroTabPage[i].TabIndex = 2;
                metroTabPage[i].Text = "Process " + (i+1).ToString();
                metroTabPage[i].VerticalScrollbarBarColor = true;
                metroTabPage[i].VerticalScrollbarHighlightOnWheel = false;
                metroTabPage[i].VerticalScrollbarSize = 10;
                metroTabPage[i].Click += new System.EventHandler(this.metroTabPage5_Click);
                if (Form1.scheduling_algorithm == "Priority (Preemptive)" || Form1.scheduling_algorithm == "Priority (Non-preemptive)")
                {
                    Panel p = new Panel();
                    p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(178)))), ((int)(((byte)(151)))));
                    p.Location = new System.Drawing.Point(320, 25);
                    p.Name = "panel5";
                    p.Size = new System.Drawing.Size(29, 75);
                    p.TabIndex = 5;
                    metroTabPage[i].Controls.Add(p);
                    Label q = new Label();
                    q.AutoSize = true;
                    q.BackColor = System.Drawing.Color.White;
                    q.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    q.Location = new System.Drawing.Point(390, 25);
                    q.Name = "label2";
                    q.Size = new System.Drawing.Size(144, 38);
                    q.TabIndex = 7;
                    q.Text = "Enter priority";
                    metroTabPage[i].Controls.Add(q);
                    priority[i] = new NumericUpDown();
                    priority[i].Location = new System.Drawing.Point(400, 80);
                    priority[i].Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
                    priority[i].Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                    priority[i].Name = "numericUpDown1";
                    priority[i].Size = new System.Drawing.Size(237, 20);
                    priority[i].TabIndex = 3;
                    priority[i].Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                    metroTabPage[i].Controls.Add(priority[i]);
                }

                metroTabPage[i].Controls.Add(numericUpDown[i]);
                metroTabPage[i].Controls.Add(numericUpDown2[i]);
                this.metroTabControl2.Controls.Add(metroTabPage[i]);

            }
            // 
            this.metroTabControl2.Location = new System.Drawing.Point(1, 51);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(714, 340);
            this.metroTabControl2.TabIndex = 15;
            this.metroTabControl2.UseSelectable = true;
            this.Controls.Add(metroTabControl2);
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void next_info_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            //label2.Text= Form1.number_process;
        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 y = new Form3();
            y.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
