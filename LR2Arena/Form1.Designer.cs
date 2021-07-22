using System;

namespace LR2Arena
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BmsMd5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BmsPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IpConfirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Ip = new System.Windows.Forms.TextBox();
            this.InjectDllButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ShowIp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bmsInfoLocal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bmsInfoRemote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UnfreezeLr2 = new System.Windows.Forms.Button();
            this.ConnectivityCheck = new System.Windows.Forms.Button();
            this.AlwaysOnTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(12, 471);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(776, 81);
            this.Log.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log:";
            // 
            // BmsMd5
            // 
            this.BmsMd5.Location = new System.Drawing.Point(48, 304);
            this.BmsMd5.Name = "BmsMd5";
            this.BmsMd5.ReadOnly = true;
            this.BmsMd5.Size = new System.Drawing.Size(740, 20);
            this.BmsMd5.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MD5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Path";
            // 
            // BmsPath
            // 
            this.BmsPath.Location = new System.Drawing.Point(48, 278);
            this.BmsPath.Name = "BmsPath";
            this.BmsPath.ReadOnly = true;
            this.BmsPath.Size = new System.Drawing.Size(740, 20);
            this.BmsPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selected chart:";
            // 
            // IpConfirm
            // 
            this.IpConfirm.Location = new System.Drawing.Point(713, 10);
            this.IpConfirm.Name = "IpConfirm";
            this.IpConfirm.Size = new System.Drawing.Size(75, 23);
            this.IpConfirm.TabIndex = 8;
            this.IpConfirm.Text = "OK";
            this.IpConfirm.UseVisualStyleBackColor = true;
            this.IpConfirm.Click += new System.EventHandler(this.IpConfirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Remote IP";
            // 
            // Ip
            // 
            this.Ip.Location = new System.Drawing.Point(72, 12);
            this.Ip.Name = "Ip";
            this.Ip.Size = new System.Drawing.Size(563, 20);
            this.Ip.TabIndex = 10;
            this.Ip.UseSystemPasswordChar = true;
            this.Ip.TextChanged += new System.EventHandler(this.Ip_TextChanged);
            // 
            // InjectDllButton
            // 
            this.InjectDllButton.Enabled = false;
            this.InjectDllButton.Location = new System.Drawing.Point(12, 38);
            this.InjectDllButton.Name = "InjectDllButton";
            this.InjectDllButton.Size = new System.Drawing.Size(470, 63);
            this.InjectDllButton.TabIndex = 11;
            this.InjectDllButton.Text = "Inject DLL (make sure LR2 is running!)";
            this.InjectDllButton.UseVisualStyleBackColor = true;
            this.InjectDllButton.Click += new System.EventHandler(this.InjectDllButton_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 107);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Name = "Score";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 143);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // ShowIp
            // 
            this.ShowIp.AutoSize = true;
            this.ShowIp.Location = new System.Drawing.Point(641, 14);
            this.ShowIp.Name = "ShowIp";
            this.ShowIp.Size = new System.Drawing.Size(66, 17);
            this.ShowIp.TabIndex = 13;
            this.ShowIp.Text = "Show IP";
            this.ShowIp.UseVisualStyleBackColor = true;
            this.ShowIp.CheckedChanged += new System.EventHandler(this.ShowIp_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Local";
            // 
            // bmsInfoLocal
            // 
            this.bmsInfoLocal.Location = new System.Drawing.Point(62, 382);
            this.bmsInfoLocal.Name = "bmsInfoLocal";
            this.bmsInfoLocal.ReadOnly = true;
            this.bmsInfoLocal.Size = new System.Drawing.Size(726, 20);
            this.bmsInfoLocal.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Remote";
            // 
            // bmsInfoRemote
            // 
            this.bmsInfoRemote.Location = new System.Drawing.Point(62, 408);
            this.bmsInfoRemote.Name = "bmsInfoRemote";
            this.bmsInfoRemote.ReadOnly = true;
            this.bmsInfoRemote.Size = new System.Drawing.Size(726, 20);
            this.bmsInfoRemote.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "BMS info:";
            // 
            // UnfreezeLr2
            // 
            this.UnfreezeLr2.Enabled = false;
            this.UnfreezeLr2.Location = new System.Drawing.Point(641, 39);
            this.UnfreezeLr2.Name = "UnfreezeLr2";
            this.UnfreezeLr2.Size = new System.Drawing.Size(147, 62);
            this.UnfreezeLr2.TabIndex = 19;
            this.UnfreezeLr2.Text = "Force P2 ready (if stuck on loading)";
            this.UnfreezeLr2.UseVisualStyleBackColor = true;
            this.UnfreezeLr2.Click += new System.EventHandler(this.UnfreezeLr2_Click);
            // 
            // ConnectivityCheck
            // 
            this.ConnectivityCheck.Enabled = false;
            this.ConnectivityCheck.Location = new System.Drawing.Point(488, 39);
            this.ConnectivityCheck.Name = "ConnectivityCheck";
            this.ConnectivityCheck.Size = new System.Drawing.Size(147, 62);
            this.ConnectivityCheck.TabIndex = 20;
            this.ConnectivityCheck.Text = "Check connectivity";
            this.ConnectivityCheck.UseVisualStyleBackColor = true;
            this.ConnectivityCheck.Click += new System.EventHandler(this.ConnectivityCheck_Click);
            // 
            // AlwaysOnTop
            // 
            this.AlwaysOnTop.AutoSize = true;
            this.AlwaysOnTop.Checked = true;
            this.AlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlwaysOnTop.Location = new System.Drawing.Point(12, 558);
            this.AlwaysOnTop.Name = "AlwaysOnTop";
            this.AlwaysOnTop.Size = new System.Drawing.Size(194, 17);
            this.AlwaysOnTop.TabIndex = 21;
            this.AlwaysOnTop.Text = "Make LR2Arena always stay on top";
            this.AlwaysOnTop.UseVisualStyleBackColor = true;
            this.AlwaysOnTop.CheckedChanged += new System.EventHandler(this.AlwaysOnTop_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 582);
            this.Controls.Add(this.AlwaysOnTop);
            this.Controls.Add(this.ConnectivityCheck);
            this.Controls.Add(this.UnfreezeLr2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bmsInfoLocal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bmsInfoRemote);
            this.Controls.Add(this.ShowIp);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.InjectDllButton);
            this.Controls.Add(this.Ip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IpConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BmsPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BmsMd5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Log);
            this.Name = "Form1";
            this.Text = "LR2Arena";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BmsMd5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BmsPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button IpConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Ip;
        private System.Windows.Forms.Button InjectDllButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox ShowIp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bmsInfoLocal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bmsInfoRemote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button UnfreezeLr2;
        private System.Windows.Forms.Button ConnectivityCheck;
        private System.Windows.Forms.CheckBox AlwaysOnTop;
    }
}

