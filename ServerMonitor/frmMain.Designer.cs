namespace ServerMonitor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDevices = new System.Windows.Forms.TableLayoutPanel();
            this.lblPingText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanelDevices);
            this.groupBox1.Controls.Add(this.lblPingText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 997);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // tableLayoutPanelDevices
            // 
            this.tableLayoutPanelDevices.ColumnCount = 2;
            this.tableLayoutPanelDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDevices.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanelDevices.Name = "tableLayoutPanelDevices";
            this.tableLayoutPanelDevices.RowCount = 2;
            this.tableLayoutPanelDevices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDevices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDevices.Size = new System.Drawing.Size(1002, 967);
            this.tableLayoutPanelDevices.TabIndex = 6;
            // 
            // lblPingText
            // 
            this.lblPingText.AutoSize = true;
            this.lblPingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold);
            this.lblPingText.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPingText.Location = new System.Drawing.Point(421, 0);
            this.lblPingText.Name = "lblPingText";
            this.lblPingText.Size = new System.Drawing.Size(102, 26);
            this.lblPingText.TabIndex = 5;
            this.lblPingText.Text = "pingText";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1008, 997);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Ping Device";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPingText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDevices;
    }
}
