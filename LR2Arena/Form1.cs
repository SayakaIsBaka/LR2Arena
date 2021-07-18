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
            }
        }

        private void Ip_TextChanged(object sender, EventArgs e)
        {
            IpConfirm.Enabled = true;
        }
    }
}
