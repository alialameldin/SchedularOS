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
    public partial class Form3 : Form
    {
        
        public static Queue<processINFO> Scheduler;
        public static processINFO[] p;
        public static float avgTurnaround;
        public static float avgWaiting; 
        public static System.Drawing.Color[] col = new System.Drawing.Color[61];
        public static Panel[] panels = new Panel[Form1.number_process];
        public static int u;
        public static int process_number = 0;


        public Form3()
        {
            InitializeComponent();
            panels = new Panel[Form1.number_process];
            u = 50;
            label4.Text = "calculating...";
            label4.ForeColor = System.Drawing.Color.Gray;
            p = new processINFO[Form1.number_process];//4 is no of processes
            for (int i = 0; i < Form1.number_process; i++)
            {
                p[i] = new processINFO();
                p[i].index = i;//index
                p[i].ATime = (int)Form2.numericUpDown2[i].Value;//arrival Time
                p[i].rtime = (int)Form2.numericUpDown[i].Value;//cpu Burst
                p[i].time = (int)Form2.numericUpDown[i].Value;//cpu Burst
                if (Form1.scheduling_algorithm == "Priority (Non-preemptive)" || Form1.scheduling_algorithm == "Priority (Preemptive)")
                    p[i].priority = (int)Form2.priority[i].Value;
                
            }
            
            if(Form1.scheduling_algorithm=="SJF (Preemptive)")
                Algorthim.SJFPREE(p, ref Scheduler, ref avgTurnaround, ref avgWaiting);
            else if (Form1.scheduling_algorithm == "SJF (Non-preemptive)")
                Algorthim.SJFNONPREE(p, ref Scheduler, ref avgTurnaround, ref avgWaiting);
            else if (Form1.scheduling_algorithm == "RoundRobin")
                Algorthim.RR(p, ref Scheduler,(int)Form2.qnum.Value, ref avgTurnaround, ref avgWaiting);
            else if (Form1.scheduling_algorithm == "FCFS")
                Algorthim.FCFS(p, ref Scheduler, ref avgTurnaround, ref avgWaiting);
            else if (Form1.scheduling_algorithm == "Priority (Non-preemptive)")
                Algorthim.priority_nonPreemp(p, ref Scheduler, ref avgTurnaround, ref avgWaiting);
            else if (Form1.scheduling_algorithm == "Priority (Preemptive)")
                Algorthim.priority_preemptive(p, ref Scheduler, ref avgTurnaround, ref avgWaiting);
            timer1.Enabled = true;
            col[0] = Color.Blue;
            col[1] = Color.Red;
            col[2] = Color.Orange;
            col[3] = Color.Black;
            col[4] = Color.Gray;
            col[5] = Color.Brown;
            col[6] = Color.Purple;
            col[7] = Color.DarkCyan;
            col[8] = Color.Green;
            col[9] = Color.DeepSkyBlue;
            col[10] = Color.Salmon;
            col[11] = Color.DarkKhaki;
            col[12] = Color.Turquoise;
            col[13] = Color.Silver;
            col[14] = Color.DarkGoldenrod;
            col[15] = Color.Olive;
            col[16] = Color.Yellow;
            col[17] = Color.Plum;
            col[18] = Color.Navy;
            col[19] = Color.LightSlateGray;
            col[20] = Color.Firebrick;
            col[21] = Color.DarkRed;
            col[22] = Color.Chartreuse;
            col[23] = Color.DarkOrange;
            col[24] = Color.DeepPink;
            col[25] = Color.Gainsboro;
            col[26] = Color.Teal;
            col[27] = Color.DarkMagenta;
            col[28] = Color.DarkSeaGreen;
            col[29] = Color.DarkGray;
            col[30] = Color.DarkSalmon;
            col[31] = Color.Blue;
            col[32] = Color.Red;
            col[33] = Color.Orange;
            col[34] = Color.Black;
            col[35] = Color.Gray;
            col[36] = Color.Brown;
            col[37] = Color.Purple;
            col[38] = Color.DarkCyan;
            col[39] = Color.Green;
            col[40] = Color.DeepSkyBlue;
            col[41] = Color.Salmon;
            col[42] = Color.DarkKhaki;
            col[43] = Color.Turquoise;
            col[44] = Color.Silver;
            col[45] = Color.DarkGoldenrod;
            col[46] = Color.Olive;
            col[47] = Color.Yellow;
            col[48] = Color.Plum;
            col[49] = Color.Navy;
            col[50] = Color.LightSlateGray;
            col[51] = Color.Firebrick;
            col[52] = Color.DarkRed;
            col[53] = Color.Chartreuse;
            col[54] = Color.DarkOrange;
            col[55] = Color.DeepPink;
            col[56] = Color.Gainsboro;
            col[57] = Color.Teal;
            col[58] = Color.DarkMagenta;
            col[59] = Color.DarkSeaGreen;
            col[60] = Color.DarkGray;


        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        
        void drawing_shape(int x, int index)
        {
            if (index == -1)
            {
                Panel ideal = new Panel(); 
                Label process_name = new Label();
                Label process_start = new Label();
                Label process_end = new Label();
                Microsoft.VisualBasic.PowerPacks.LineShape lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                Microsoft.VisualBasic.PowerPacks.LineShape lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                ideal.Height = 50;
                ideal.Width = x;
                ideal.BackColor = Color.BurlyWood;
                ideal.Location = new System.Drawing.Point(u, 40);
                process_name.AutoSize = true;
                process_name.BackColor = Color.BurlyWood;
                process_name.ForeColor = System.Drawing.Color.White;
                process_name.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_name.Location = new System.Drawing.Point(u + (x / 2) - 22, 52);
                process_name.Name = "label2";
                process_name.TabIndex = 7;
                process_name.Text = "idle";
                process_start.AutoSize = true;
                process_start.ForeColor = System.Drawing.Color.Black;
                process_start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                process_start.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_start.Location = new System.Drawing.Point(u - 13, 120);
                process_start.Name = "label2";
                process_start.TabIndex = 7;
                process_start.Text = "" + (u - 50) / 50;
                lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                lineShape1.BorderWidth = 3;
                lineShape1.Name = "lineShape1";
                lineShape1.X1 = u;
                lineShape1.X2 = u;
                lineShape1.Y1 = 40;
                lineShape1.Y2 = 125;
                u = u + x;
                process_end.AutoSize = true;
                process_end.ForeColor = System.Drawing.Color.Black;
                process_end.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                process_end.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_end.Location = new System.Drawing.Point(u - 13, 120);
                process_end.Name = "label2";
                process_end.TabIndex = 7;
                process_end.Text = "" + (u - 50) / 50;
                lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                lineShape2.BorderWidth = 3;
                lineShape2.Name = "lineShape1";
                lineShape2.X1 = u;
                lineShape2.X2 = u;
                lineShape2.Y1 = 40;
                lineShape2.Y2 = 125;
                this.panel4.Controls.Add(process_name);
                this.panel4.Controls.Add(ideal);
                this.panel4.Controls.Add(process_start);
                this.panel4.Controls.Add(process_end);
                shapeContainer1.Location = new System.Drawing.Point(0, 0);
                shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                shapeContainer1.Name = "shapeContainer1";
                shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
                lineShape1});
                shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
                lineShape2});
                shapeContainer1.Size = new System.Drawing.Size(714, 393);
                shapeContainer1.TabIndex = 3;
                shapeContainer1.TabStop = false;
                this.panel4.Controls.Add(shapeContainer1);

            }
            else {
                panels[index] = new Panel();
                Label process_name = new Label();
                Label process_start = new Label();
                Label process_end = new Label();
                Microsoft.VisualBasic.PowerPacks.LineShape lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                Microsoft.VisualBasic.PowerPacks.LineShape lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                panels[index].Name = "q" + index.ToString();
                panels[index].Height = 50;
                panels[index].Width = x;
                panels[index].BackColor = col[index];
                panels[index].Location = new System.Drawing.Point(u, 40);
                process_name.AutoSize = true;
                process_name.BackColor = col[index];
                process_name.ForeColor = System.Drawing.Color.White;
                process_name.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_name.Location = new System.Drawing.Point(u + (x / 2) - 13, 52);
                process_name.Name = "label2";
                process_name.TabIndex = 7;
                process_name.Text = "P" + (index + 1);
                process_start.AutoSize = true;
                process_start.ForeColor = System.Drawing.Color.Black;
                process_start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                process_start.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_start.Location = new System.Drawing.Point(u - 13, 120);
                process_start.Name = "label2";
                process_start.TabIndex = 7;
                process_start.Text = "" + (u - 50) / 50;
                lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                lineShape1.BorderWidth = 3;
                lineShape1.Name = "lineShape1";
                lineShape1.X1 = u;
                lineShape1.X2 = u;
                lineShape1.Y1 = 40;
                lineShape1.Y2 = 125;
                u = u + x;
                process_end.AutoSize = true;
                process_end.ForeColor = System.Drawing.Color.Black;
                process_end.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                process_end.Font = new System.Drawing.Font("Comic Sans MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                process_end.Location = new System.Drawing.Point(u - 13, 120);
                process_end.Name = "label2";
                process_end.TabIndex = 7;
                process_end.Text = "" + (u - 50) / 50;
                lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                lineShape2.BorderWidth = 3;
                lineShape2.Name = "lineShape1";
                lineShape2.X1 = u;
                lineShape2.X2 = u;
                lineShape2.Y1 = 40;
                lineShape2.Y2 = 125;
                this.panel4.Controls.Add(process_name);
                this.panel4.Controls.Add(panels[index]);
                this.panel4.Controls.Add(process_start);
                this.panel4.Controls.Add(process_end);
                shapeContainer1.Location = new System.Drawing.Point(0, 0);
                shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                shapeContainer1.Name = "shapeContainer1";
                shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            lineShape1});
                shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            lineShape2});
                shapeContainer1.Size = new System.Drawing.Size(714, 393);
                shapeContainer1.TabIndex = 3;
                shapeContainer1.TabStop = false;
                this.panel4.Controls.Add(shapeContainer1);
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                drawing_shape(Scheduler.Peek().rtime * 50, Scheduler.Peek().index);
                Scheduler.Dequeue();
                if (Scheduler.Count == 0)
                {
                    timer1.Enabled = false;
                    label4.ForeColor = System.Drawing.Color.Black;
                    label4.Text = avgWaiting.ToString();
                }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void next_info_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
