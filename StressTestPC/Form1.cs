using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace StressTestPC
{
    public partial class Form1 : Form
    {
        LoadManager manager;
        MessageBx one;

        int processorCount = Environment.ProcessorCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label[] lblCPU = new Label[processorCount];
            TrackBar[] tBar = new TrackBar[processorCount];

            GroupBox[] grpCPU = new GroupBox[processorCount];
            for (int i = 0; i < processorCount; i++)
            {
                int yOffset = 17;
                grpCPU[i] = new GroupBox();
                grpCPU[i].Text = "CPU" + i.ToString();
                grpCPU[i].Size = new Size(350, 50);
                grpCPU[i].Location = new Point(20, i * 60);

                RadioButton rbtnMin = new RadioButton();
                RadioButton rbtnMed = new RadioButton();
                RadioButton rbtnMax = new RadioButton();

                grpCPU[i].Controls.Add(rbtnMin);
                grpCPU[i].Controls.Add(rbtnMed);
                grpCPU[i].Controls.Add(rbtnMax);

                rbtnMin.Text = "Минимальная";
                rbtnMin.AutoSize = true;
                rbtnMin.Location = new Point(30, yOffset);
                rbtnMin.Checked = true;
                rbtnMin.Click += rbt_Click;
                rbtnMin.Tag = i.ToString() + ",0";

                rbtnMed.Text = "Средняя";
                rbtnMed.AutoSize = true;
                rbtnMed.Location = new Point(130, yOffset);
                rbtnMed.Click += rbt_Click;
                rbtnMed.Tag = i.ToString() + ",50";

                rbtnMax.Text = "Максимальная";
                rbtnMax.AutoSize = true;
                rbtnMax.Location = new Point(205, yOffset);
                rbtnMax.Click += rbt_Click;
                rbtnMax.Tag = i.ToString() + ",100";

                pnlCPU.Controls.Add(grpCPU[i]);

            }
            manager = new LoadManager();
        }

        void rbt_Click(object sender, EventArgs e)
        {
            RadioButton chkBox = sender as RadioButton;
            if (chkBox != null)
            {
                string data = chkBox.Tag.ToString();
                string[] input = data.Split(new char[] { ',' });
                manager.SetLoad(int.Parse(input[0]), int.Parse(input[1]));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            manager.Dispose();
        }

        private void pnlCPU_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblProc.Text = HardwareInfo.GetProcessorInformation();
            lblMath.Text = HardwareInfo.GetBoardName();
            lblChip.Text = HardwareInfo.GetBoardMaker();
            lblVideo.Text = HardwareInfo.GetVideoController();
            lblOzy.Text = HardwareInfo.GetPhysicalMemory();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(performanceCounter1.NextValue());
            label5.Text = "CPU: " + progressBar1.Value.ToString() + "%";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.Value = (int)(performanceCounter2.NextValue());
            label7.Text = "Использовано ОЗУ: " + progressBar2.Value.ToString() + "%";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            one = new MessageBx();
            one.MessageBoxNew();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}