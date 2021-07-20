using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2Arena
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillChart();
        }

        private void FillChart()
        {
            chart1.Series["Score"].Points.AddXY("You", "0");
            chart1.Series["Score"].Points.AddXY("P2", "0");
            chart1.ChartAreas[0].AxisY.Maximum = 10000;
        }

        private void IpConfirm_Click(object sender, EventArgs e)
        {
            string ip = Ip.Text;
            if (!UdpManager.SetRemoteAddress(ip, 2224))
            {
                MessageBox.Show("Invalid IP, please verify that you wrote it correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IpConfirm.Enabled = false;
                InjectDllButton.Enabled = true;
            }
        }

        private void Ip_TextChanged(object sender, EventArgs e)
        {
            IpConfirm.Enabled = true;
        }

        private void InjectDllButton_Click(object sender, EventArgs e)
        {
            if (!Init.Initialize(this))
            {
                MessageBox.Show("Error while injecting DLL, make sure LR2 is running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InjectDllButton.Enabled = false;
                InjectDllButton.Text = "Successfully injected DLL!";
                UnfreezeLr2.Enabled = true;
            }
        }

        private void ShowIp_CheckedChanged(object sender, EventArgs e)
        {
            Ip.UseSystemPasswordChar = !Ip.UseSystemPasswordChar;
        }

        public void SetLogTextBox(string message)
        {
            Log.Text = message;
        }

        public void AddLogTextBoxLine(string message)
        {
            Log.AppendText(message);
            Log.AppendText(Environment.NewLine);
        }

        public void SetBmsMd5TextBox(string message)
        {
            BmsMd5.Text = message;
        }

        public void SetBmsPathTextBox(string message)
        {
            BmsPath.Text = message;
        }

        public void UpdateGraph(uint value, int pointIndex)
        {
            chart1.Series["Score"].Points[pointIndex].YValues[0] = (double)value;
            chart1.Refresh();
        }

        public void SetBmsInfoLocalTextBox(string message)
        {
            bmsInfoLocal.Text = message;
        }

        public void SetBmsInfoRemoteTextBox(string message)
        {
            bmsInfoRemote.Text = message;
        }

        private void UnfreezeLr2_Click(object sender, EventArgs e)
        {
            UdpManager.SendP2ReadyToLR2();
        }
    }
}
