namespace SampleMain
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_listen = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.btn_stopListen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(110, 100);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(122, 38);
            this.btn_listen.TabIndex = 1;
            this.btn_listen.Text = "listen";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(654, 100);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(122, 38);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_log
            // 
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(0, 0);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(800, 470);
            this.txt_log.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_stopListen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_listen);
            this.panel1.Controls.Add(this.btn_connect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 151);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_log);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 470);
            this.panel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ipAddr1);
            this.groupBox1.Controls.Add(this.txt_portNo1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local";
            // 
            // txt_ipAddr1
            // 
            this.txt_ipAddr1.Location = new System.Drawing.Point(55, 30);
            this.txt_ipAddr1.Name = "txt_ipAddr1";
            this.txt_ipAddr1.Size = new System.Drawing.Size(165, 31);
            this.txt_ipAddr1.TabIndex = 2;
            this.txt_ipAddr1.Text = "192.168.179.2";
            // 
            // txt_portNo1
            // 
            this.txt_portNo1.Location = new System.Drawing.Point(282, 30);
            this.txt_portNo1.Name = "txt_portNo1";
            this.txt_portNo1.Size = new System.Drawing.Size(89, 31);
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
            this.groupBox2.Location = new System.Drawing.Point(409, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 82);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote";
            // 
            // txt_ipAddr2
            // 
            this.txt_ipAddr2.Location = new System.Drawing.Point(55, 30);
            this.txt_ipAddr2.Name = "txt_ipAddr2";
            this.txt_ipAddr2.Size = new System.Drawing.Size(165, 31);
            this.txt_ipAddr2.TabIndex = 2;
            this.txt_ipAddr2.Text = "192.168.179.2";
            // 
            // txt_portNo2
            // 
            this.txt_portNo2.Location = new System.Drawing.Point(282, 30);
            this.txt_portNo2.Name = "txt_portNo2";
            this.txt_portNo2.Size = new System.Drawing.Size(85, 31);
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
            // btn_stopListen
            // 
            this.btn_stopListen.Location = new System.Drawing.Point(242, 100);
            this.btn_stopListen.Name = "btn_stopListen";
            this.btn_stopListen.Size = new System.Drawing.Size(147, 38);
            this.btn_stopListen.TabIndex = 10;
            this.btn_stopListen.Text = "stop listen";
            this.btn_stopListen.UseVisualStyleBackColor = true;
            this.btn_stopListen.Click += new System.EventHandler(this.btn_stopListen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 621);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_stopListen;
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
    }
}

