namespace SampleMain
{
    partial class SocketForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_sendData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ipAddr1 = new System.Windows.Forms.TextBox();
            this.txt_portNo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ipAddr2 = new System.Windows.Forms.TextBox();
            this.txt_portNo2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.txt_sendData);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 256);
            this.panel1.TabIndex = 0;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(651, 192);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(124, 45);
            this.btn_send.TabIndex = 9;
            this.btn_send.Text = "送信";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_sendData
            // 
            this.txt_sendData.Location = new System.Drawing.Point(12, 91);
            this.txt_sendData.Multiline = true;
            this.txt_sendData.Name = "txt_sendData";
            this.txt_sendData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_sendData.Size = new System.Drawing.Size(795, 95);
            this.txt_sendData.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ipAddr1);
            this.groupBox1.Controls.Add(this.txt_portNo1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 82);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local";
            // 
            // txt_ipAddr1
            // 
            this.txt_ipAddr1.Enabled = false;
            this.txt_ipAddr1.Location = new System.Drawing.Point(55, 30);
            this.txt_ipAddr1.Name = "txt_ipAddr1";
            this.txt_ipAddr1.Size = new System.Drawing.Size(165, 31);
            this.txt_ipAddr1.TabIndex = 2;
            // 
            // txt_portNo1
            // 
            this.txt_portNo1.Enabled = false;
            this.txt_portNo1.Location = new System.Drawing.Point(282, 30);
            this.txt_portNo1.Name = "txt_portNo1";
            this.txt_portNo1.Size = new System.Drawing.Size(83, 31);
            this.txt_portNo1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ipAddr2);
            this.groupBox2.Controls.Add(this.txt_portNo2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(413, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 82);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote";
            // 
            // txt_ipAddr2
            // 
            this.txt_ipAddr2.Enabled = false;
            this.txt_ipAddr2.Location = new System.Drawing.Point(55, 30);
            this.txt_ipAddr2.Name = "txt_ipAddr2";
            this.txt_ipAddr2.Size = new System.Drawing.Size(165, 31);
            this.txt_ipAddr2.TabIndex = 2;
            // 
            // txt_portNo2
            // 
            this.txt_portNo2.Enabled = false;
            this.txt_portNo2.Location = new System.Drawing.Point(282, 30);
            this.txt_portNo2.Name = "txt_portNo2";
            this.txt_portNo2.Size = new System.Drawing.Size(80, 31);
            this.txt_portNo2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "ip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "port";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_log);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 318);
            this.panel2.TabIndex = 1;
            // 
            // txt_log
            // 
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(0, 0);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(822, 318);
            this.txt_log.TabIndex = 1;
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 574);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SocketForm";
            this.Text = "送受信";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SocketForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ipAddr1;
        private System.Windows.Forms.TextBox txt_portNo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ipAddr2;
        private System.Windows.Forms.TextBox txt_portNo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_sendData;
        private System.Windows.Forms.TextBox txt_log;
    }
}