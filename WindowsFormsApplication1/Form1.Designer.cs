namespace WindowsFormsApplication1
{
    partial class OracleAuthDecryptor
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_AUTH_SESSKEY_srv = new System.Windows.Forms.TextBox();
            this.textBox_AUTH_VFR_DATA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_USERNAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Try = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Test = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_AUTH_SESSKEY_clnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_AUTH_PASSWORD = new System.Windows.Forms.TextBox();
            this.button_load_data = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_AUTH_PBKDF2_SPEEDY_KEY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_PBKDF2Salt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_PBKDF2SderCount = new System.Windows.Forms.TextBox();
            this.textBox_PBKDF2VgenCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LoadDict = new System.Windows.Forms.Button();
            this.ResultFile_Click = new System.Windows.Forms.Button();
            this.BruteProgress = new System.Windows.Forms.ProgressBar();
            this.checkBox_findEquivalent = new System.Windows.Forms.CheckBox();
            this.checkBox_useTotalBrute = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_AUTH_SESSKEY_srv
            // 
            this.textBox_AUTH_SESSKEY_srv.Location = new System.Drawing.Point(12, 29);
            this.textBox_AUTH_SESSKEY_srv.MaxLength = 96;
            this.textBox_AUTH_SESSKEY_srv.Name = "textBox_AUTH_SESSKEY_srv";
            this.textBox_AUTH_SESSKEY_srv.Size = new System.Drawing.Size(641, 20);
            this.textBox_AUTH_SESSKEY_srv.TabIndex = 0;
            // 
            // textBox_AUTH_VFR_DATA
            // 
            this.textBox_AUTH_VFR_DATA.Location = new System.Drawing.Point(12, 383);
            this.textBox_AUTH_VFR_DATA.MaxLength = 32;
            this.textBox_AUTH_VFR_DATA.Name = "textBox_AUTH_VFR_DATA";
            this.textBox_AUTH_VFR_DATA.Size = new System.Drawing.Size(230, 20);
            this.textBox_AUTH_VFR_DATA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AUTH_SESSKEY from Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AUTH_VFR_DATA";
            // 
            // textBox_USERNAME
            // 
            this.textBox_USERNAME.Location = new System.Drawing.Point(12, 331);
            this.textBox_USERNAME.MaxLength = 40;
            this.textBox_USERNAME.Name = "textBox_USERNAME";
            this.textBox_USERNAME.Size = new System.Drawing.Size(230, 20);
            this.textBox_USERNAME.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "USERNAME";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Oracle 10g (any versions)",
            "Oracle 11g ( any versions)",
            "Oracle 11g ( 11.2.0.3 or older)",
            "Oracle 11g ( 11.2.0.4 or later)",
            "Oracle 12g",
            "Oracle 12c (12.0.1.1 or later)",
            "Oracle 12c (12.0.1.2 or older)",
            "Oracle 18c",
            "Oracle 19c"});
            this.listBox1.Location = new System.Drawing.Point(248, 334);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 69);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Version";
            // 
            // button_Try
            // 
            this.button_Try.Location = new System.Drawing.Point(484, 352);
            this.button_Try.Name = "button_Try";
            this.button_Try.Size = new System.Drawing.Size(82, 23);
            this.button_Try.TabIndex = 8;
            this.button_Try.Text = "Try";
            this.button_Try.UseVisualStyleBackColor = true;
            this.button_Try.Click += new System.EventHandler(this.button_Try_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(572, 352);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(81, 23);
            this.button_Clear.TabIndex = 9;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(571, 381);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(82, 23);
            this.button_Test.TabIndex = 10;
            this.button_Test.Text = "Test";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "AUTH_SESSKEY from client";
            // 
            // textBox_AUTH_SESSKEY_clnt
            // 
            this.textBox_AUTH_SESSKEY_clnt.Location = new System.Drawing.Point(12, 77);
            this.textBox_AUTH_SESSKEY_clnt.Name = "textBox_AUTH_SESSKEY_clnt";
            this.textBox_AUTH_SESSKEY_clnt.Size = new System.Drawing.Size(641, 20);
            this.textBox_AUTH_SESSKEY_clnt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "AUTH_PASSWORD";
            // 
            // textBox_AUTH_PASSWORD
            // 
            this.textBox_AUTH_PASSWORD.Location = new System.Drawing.Point(12, 125);
            this.textBox_AUTH_PASSWORD.Name = "textBox_AUTH_PASSWORD";
            this.textBox_AUTH_PASSWORD.Size = new System.Drawing.Size(641, 20);
            this.textBox_AUTH_PASSWORD.TabIndex = 14;
            // 
            // button_load_data
            // 
            this.button_load_data.Location = new System.Drawing.Point(484, 381);
            this.button_load_data.Name = "button_load_data";
            this.button_load_data.Size = new System.Drawing.Size(82, 23);
            this.button_load_data.TabIndex = 15;
            this.button_load_data.Text = "LOAD .pcap";
            this.button_load_data.UseVisualStyleBackColor = true;
            this.button_load_data.Click += new System.EventHandler(this.button_load_data_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_AUTH_PBKDF2_SPEEDY_KEY
            // 
            this.textBox_AUTH_PBKDF2_SPEEDY_KEY.Location = new System.Drawing.Point(12, 174);
            this.textBox_AUTH_PBKDF2_SPEEDY_KEY.Name = "textBox_AUTH_PBKDF2_SPEEDY_KEY";
            this.textBox_AUTH_PBKDF2_SPEEDY_KEY.Size = new System.Drawing.Size(641, 20);
            this.textBox_AUTH_PBKDF2_SPEEDY_KEY.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "AUTH_PBKDF2_SPEEDY_KEY";
            // 
            // textBox_PBKDF2Salt
            // 
            this.textBox_PBKDF2Salt.Location = new System.Drawing.Point(12, 222);
            this.textBox_PBKDF2Salt.Name = "textBox_PBKDF2Salt";
            this.textBox_PBKDF2Salt.Size = new System.Drawing.Size(641, 20);
            this.textBox_PBKDF2Salt.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "PBKDF2Salt";
            // 
            // textBox_PBKDF2SderCount
            // 
            this.textBox_PBKDF2SderCount.Location = new System.Drawing.Point(12, 279);
            this.textBox_PBKDF2SderCount.Name = "textBox_PBKDF2SderCount";
            this.textBox_PBKDF2SderCount.Size = new System.Drawing.Size(100, 20);
            this.textBox_PBKDF2SderCount.TabIndex = 22;
            // 
            // textBox_PBKDF2VgenCount
            // 
            this.textBox_PBKDF2VgenCount.Location = new System.Drawing.Point(142, 279);
            this.textBox_PBKDF2VgenCount.Name = "textBox_PBKDF2VgenCount";
            this.textBox_PBKDF2VgenCount.Size = new System.Drawing.Size(100, 20);
            this.textBox_PBKDF2VgenCount.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "PBKDF2VgenCount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "PBKDF2SderCount";
            // 
            // LoadDict
            // 
            this.LoadDict.Location = new System.Drawing.Point(484, 323);
            this.LoadDict.Name = "LoadDict";
            this.LoadDict.Size = new System.Drawing.Size(82, 23);
            this.LoadDict.TabIndex = 28;
            this.LoadDict.Text = "Load Dict";
            this.LoadDict.UseVisualStyleBackColor = true;
            this.LoadDict.Click += new System.EventHandler(this.button1_LoadDict);
            // 
            // ResultFile_Click
            // 
            this.ResultFile_Click.Location = new System.Drawing.Point(571, 323);
            this.ResultFile_Click.Name = "ResultFile_Click";
            this.ResultFile_Click.Size = new System.Drawing.Size(82, 23);
            this.ResultFile_Click.TabIndex = 29;
            this.ResultFile_Click.Text = "Result File";
            this.ResultFile_Click.UseVisualStyleBackColor = true;
            this.ResultFile_Click.Click += new System.EventHandler(this.ResultFile_Click_Click);
            // 
            // BruteProgress
            // 
            this.BruteProgress.Location = new System.Drawing.Point(248, 279);
            this.BruteProgress.Name = "BruteProgress";
            this.BruteProgress.Size = new System.Drawing.Size(396, 23);
            this.BruteProgress.TabIndex = 30;
            this.BruteProgress.Click += new System.EventHandler(this.BruteProgress_Click);
            // 
            // checkBox_findEquivalent
            // 
            this.checkBox_findEquivalent.AutoSize = true;
            this.checkBox_findEquivalent.Location = new System.Drawing.Point(521, 252);
            this.checkBox_findEquivalent.Name = "checkBox_findEquivalent";
            this.checkBox_findEquivalent.Size = new System.Drawing.Size(95, 17);
            this.checkBox_findEquivalent.TabIndex = 17;
            this.checkBox_findEquivalent.Text = "find equivalent";
            this.checkBox_findEquivalent.UseVisualStyleBackColor = true;
            // 
            // checkBox_useTotalBrute
            // 
            this.checkBox_useTotalBrute.AutoSize = true;
            this.checkBox_useTotalBrute.Location = new System.Drawing.Point(361, 252);
            this.checkBox_useTotalBrute.Name = "checkBox_useTotalBrute";
            this.checkBox_useTotalBrute.Size = new System.Drawing.Size(117, 17);
            this.checkBox_useTotalBrute.TabIndex = 16;
            this.checkBox_useTotalBrute.Text = "use total bruteforce";
            this.checkBox_useTotalBrute.UseVisualStyleBackColor = true;
            // 
            // OracleAuthDecryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 428);
            this.Controls.Add(this.BruteProgress);
            this.Controls.Add(this.ResultFile_Click);
            this.Controls.Add(this.LoadDict);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_PBKDF2VgenCount);
            this.Controls.Add(this.textBox_PBKDF2SderCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_PBKDF2Salt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_AUTH_PBKDF2_SPEEDY_KEY);
            this.Controls.Add(this.checkBox_findEquivalent);
            this.Controls.Add(this.checkBox_useTotalBrute);
            this.Controls.Add(this.button_load_data);
            this.Controls.Add(this.textBox_AUTH_PASSWORD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_AUTH_SESSKEY_clnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Try);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_USERNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AUTH_VFR_DATA);
            this.Controls.Add(this.textBox_AUTH_SESSKEY_srv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OracleAuthDecryptor";
            this.Text = "OracleAuthDecryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_AUTH_SESSKEY_srv;
        private System.Windows.Forms.TextBox textBox_AUTH_VFR_DATA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_USERNAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Try;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_AUTH_SESSKEY_clnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_AUTH_PASSWORD;
        private System.Windows.Forms.Button button_load_data;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_AUTH_PBKDF2_SPEEDY_KEY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_PBKDF2Salt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_PBKDF2SderCount;
        private System.Windows.Forms.TextBox textBox_PBKDF2VgenCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button LoadDict;
        private System.Windows.Forms.Button ResultFile_Click;
        private System.Windows.Forms.ProgressBar BruteProgress;
        private System.Windows.Forms.CheckBox checkBox_findEquivalent;
        private System.Windows.Forms.CheckBox checkBox_useTotalBrute;
    }
}

