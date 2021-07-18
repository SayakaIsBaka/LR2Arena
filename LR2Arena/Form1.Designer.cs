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
            this.components = new System.ComponentModel.Container();
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
            this.processorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(12, 357);
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
            this.label1.Location = new System.Drawing.Point(12, 338);
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
            this.Ip.Size = new System.Drawing.Size(635, 20);
            this.Ip.TabIndex = 10;
            this.Ip.TextChanged += new System.EventHandler(this.Ip_TextChanged);
            // 
            // InjectDllButton
            // 
            this.InjectDllButton.Enabled = false;
            this.InjectDllButton.Location = new System.Drawing.Point(12, 38);
            this.InjectDllButton.Name = "InjectDllButton";
            this.InjectDllButton.Size = new System.Drawing.Size(776, 63);
            this.InjectDllButton.TabIndex = 11;
            this.InjectDllButton.Text = "Inject DLL (make sure LR2 is running!)";
            this.InjectDllButton.UseVisualStyleBackColor = true;
            this.InjectDllButton.Click += new System.EventHandler(this.InjectDllButton_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.processorBindingSource;
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
            // processorBindingSource
            // 
            this.processorBindingSource.DataSource = typeof(LR2Arena.Processor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.BindingSource processorBindingSource;
    }
}

