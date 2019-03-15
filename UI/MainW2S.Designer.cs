namespace Way2SmsApp.UI
{
    partial class MainW2S
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
            this.tabcMain = new System.Windows.Forms.TabControl();
            this.tabpLogin = new System.Windows.Forms.TabPage();
            this.lblLog = new System.Windows.Forms.Label();
            this.cbLoginRemember = new System.Windows.Forms.CheckBox();
            this.cbLoginDefault = new System.Windows.Forms.CheckBox();
            this.btnLoginClear = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.btnLoginSubmit = new System.Windows.Forms.Button();
            this.tabpAddrbook = new System.Windows.Forms.TabPage();
            this.cbABSelectAll = new System.Windows.Forms.CheckBox();
            this.lblABMessage = new System.Windows.Forms.Label();
            this.lblABList = new System.Windows.Forms.Label();
            this.btnABClear = new System.Windows.Forms.Button();
            this.rtbABMsg = new System.Windows.Forms.RichTextBox();
            this.btnABSend = new System.Windows.Forms.Button();
            this.clbABList = new System.Windows.Forms.CheckedListBox();
            this.tabpSendSms = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabcMain.SuspendLayout();
            this.tabpLogin.SuspendLayout();
            this.tabpAddrbook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcMain
            // 
            this.tabcMain.Controls.Add(this.tabpLogin);
            this.tabcMain.Controls.Add(this.tabpAddrbook);
            this.tabcMain.Controls.Add(this.tabpSendSms);
            this.tabcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcMain.Location = new System.Drawing.Point(0, 0);
            this.tabcMain.Name = "tabcMain";
            this.tabcMain.SelectedIndex = 0;
            this.tabcMain.Size = new System.Drawing.Size(706, 496);
            this.tabcMain.TabIndex = 0;
            this.tabcMain.SelectedIndexChanged += new System.EventHandler(this.tabcMain_SelectedIndexChanged);
            // 
            // tabpLogin
            // 
            this.tabpLogin.Controls.Add(this.lblLog);
            this.tabpLogin.Controls.Add(this.cbLoginRemember);
            this.tabpLogin.Controls.Add(this.cbLoginDefault);
            this.tabpLogin.Controls.Add(this.btnLoginClear);
            this.tabpLogin.Controls.Add(this.lblLogin);
            this.tabpLogin.Controls.Add(this.tbPassword);
            this.tabpLogin.Controls.Add(this.tbLogin);
            this.tabpLogin.Controls.Add(this.lblPasswd);
            this.tabpLogin.Controls.Add(this.btnLoginSubmit);
            this.tabpLogin.Location = new System.Drawing.Point(4, 22);
            this.tabpLogin.Name = "tabpLogin";
            this.tabpLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabpLogin.Size = new System.Drawing.Size(698, 470);
            this.tabpLogin.TabIndex = 0;
            this.tabpLogin.Text = "Login";
            this.tabpLogin.UseVisualStyleBackColor = true;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(8, 28);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(35, 17);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "Log";
            // 
            // cbLoginRemember
            // 
            this.cbLoginRemember.AutoSize = true;
            this.cbLoginRemember.Location = new System.Drawing.Point(105, 204);
            this.cbLoginRemember.Name = "cbLoginRemember";
            this.cbLoginRemember.Size = new System.Drawing.Size(77, 17);
            this.cbLoginRemember.TabIndex = 8;
            this.cbLoginRemember.Text = "Remember";
            this.cbLoginRemember.UseVisualStyleBackColor = true;
            this.cbLoginRemember.CheckedChanged += new System.EventHandler(this.cbLoginRemember_CheckedChanged);
            // 
            // cbLoginDefault
            // 
            this.cbLoginDefault.AutoSize = true;
            this.cbLoginDefault.Location = new System.Drawing.Point(237, 91);
            this.cbLoginDefault.Name = "cbLoginDefault";
            this.cbLoginDefault.Size = new System.Drawing.Size(79, 17);
            this.cbLoginDefault.TabIndex = 7;
            this.cbLoginDefault.Text = "UseDefault";
            this.cbLoginDefault.UseVisualStyleBackColor = true;
            this.cbLoginDefault.CheckedChanged += new System.EventHandler(this.cbLoginDefault_CheckedChanged);
            // 
            // btnLoginClear
            // 
            this.btnLoginClear.Location = new System.Drawing.Point(158, 272);
            this.btnLoginClear.Name = "btnLoginClear";
            this.btnLoginClear.Size = new System.Drawing.Size(75, 23);
            this.btnLoginClear.TabIndex = 6;
            this.btnLoginClear.Text = "Clear";
            this.btnLoginClear.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(6, 91);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "Login";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(82, 160);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(82, 91);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // lblPasswd
            // 
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.Location = new System.Drawing.Point(6, 160);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(53, 13);
            this.lblPasswd.TabIndex = 1;
            this.lblPasswd.Text = "Password";
            // 
            // btnLoginSubmit
            // 
            this.btnLoginSubmit.Location = new System.Drawing.Point(56, 272);
            this.btnLoginSubmit.Name = "btnLoginSubmit";
            this.btnLoginSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnLoginSubmit.TabIndex = 0;
            this.btnLoginSubmit.Text = "Submit";
            this.btnLoginSubmit.UseVisualStyleBackColor = true;
            this.btnLoginSubmit.Click += new System.EventHandler(this.btnLoginSubmit_Click);
            // 
            // tabpAddrbook
            // 
            this.tabpAddrbook.Controls.Add(this.statusStrip1);
            this.tabpAddrbook.Controls.Add(this.cbABSelectAll);
            this.tabpAddrbook.Controls.Add(this.lblABMessage);
            this.tabpAddrbook.Controls.Add(this.lblABList);
            this.tabpAddrbook.Controls.Add(this.btnABClear);
            this.tabpAddrbook.Controls.Add(this.rtbABMsg);
            this.tabpAddrbook.Controls.Add(this.btnABSend);
            this.tabpAddrbook.Controls.Add(this.clbABList);
            this.tabpAddrbook.Location = new System.Drawing.Point(4, 22);
            this.tabpAddrbook.Name = "tabpAddrbook";
            this.tabpAddrbook.Padding = new System.Windows.Forms.Padding(3);
            this.tabpAddrbook.Size = new System.Drawing.Size(698, 470);
            this.tabpAddrbook.TabIndex = 1;
            this.tabpAddrbook.Text = "AddressBook";
            this.tabpAddrbook.UseVisualStyleBackColor = true;
            // 
            // cbABSelectAll
            // 
            this.cbABSelectAll.AutoSize = true;
            this.cbABSelectAll.Location = new System.Drawing.Point(560, 203);
            this.cbABSelectAll.Name = "cbABSelectAll";
            this.cbABSelectAll.Size = new System.Drawing.Size(67, 17);
            this.cbABSelectAll.TabIndex = 7;
            this.cbABSelectAll.Text = "SelectAll";
            this.cbABSelectAll.UseVisualStyleBackColor = true;
            this.cbABSelectAll.CheckedChanged += new System.EventHandler(this.cbABSelectAll_CheckedChanged);
            // 
            // lblABMessage
            // 
            this.lblABMessage.AutoSize = true;
            this.lblABMessage.Location = new System.Drawing.Point(9, 248);
            this.lblABMessage.Name = "lblABMessage";
            this.lblABMessage.Size = new System.Drawing.Size(74, 13);
            this.lblABMessage.TabIndex = 6;
            this.lblABMessage.Text = "Message Text";
            // 
            // lblABList
            // 
            this.lblABList.AutoSize = true;
            this.lblABList.Location = new System.Drawing.Point(9, 25);
            this.lblABList.Name = "lblABList";
            this.lblABList.Size = new System.Drawing.Size(70, 13);
            this.lblABList.TabIndex = 5;
            this.lblABList.Text = "AddressBook";
            // 
            // btnABClear
            // 
            this.btnABClear.Location = new System.Drawing.Point(189, 376);
            this.btnABClear.Name = "btnABClear";
            this.btnABClear.Size = new System.Drawing.Size(89, 23);
            this.btnABClear.TabIndex = 3;
            this.btnABClear.Text = "ClearMessage";
            this.btnABClear.UseVisualStyleBackColor = true;
            this.btnABClear.Click += new System.EventHandler(this.btnABClear_Click);
            // 
            // rtbABMsg
            // 
            this.rtbABMsg.Location = new System.Drawing.Point(89, 248);
            this.rtbABMsg.Name = "rtbABMsg";
            this.rtbABMsg.Size = new System.Drawing.Size(452, 96);
            this.rtbABMsg.TabIndex = 2;
            this.rtbABMsg.Text = "";
            this.rtbABMsg.TextChanged += new System.EventHandler(this.rtbABMsg_TextChanged);
            // 
            // btnABSend
            // 
            this.btnABSend.Location = new System.Drawing.Point(89, 376);
            this.btnABSend.Name = "btnABSend";
            this.btnABSend.Size = new System.Drawing.Size(75, 23);
            this.btnABSend.TabIndex = 1;
            this.btnABSend.Text = "Send";
            this.btnABSend.UseVisualStyleBackColor = true;
            this.btnABSend.Click += new System.EventHandler(this.btnABSend_Click);
            // 
            // clbABList
            // 
            this.clbABList.FormattingEnabled = true;
            this.clbABList.Location = new System.Drawing.Point(89, 6);
            this.clbABList.Name = "clbABList";
            this.clbABList.Size = new System.Drawing.Size(452, 214);
            this.clbABList.TabIndex = 0;
            // 
            // tabpSendSms
            // 
            this.tabpSendSms.Location = new System.Drawing.Point(4, 22);
            this.tabpSendSms.Name = "tabpSendSms";
            this.tabpSendSms.Padding = new System.Windows.Forms.Padding(3);
            this.tabpSendSms.Size = new System.Drawing.Size(698, 470);
            this.tabpSendSms.TabIndex = 2;
            this.tabpSendSms.Text = "QuickSMS";
            this.tabpSendSms.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 10000000;
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkRate = 10000000;
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(692, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainW2S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 496);
            this.Controls.Add(this.tabcMain);
            this.Name = "MainW2S";
            this.Text = "MainW2S";
            this.tabcMain.ResumeLayout(false);
            this.tabpLogin.ResumeLayout(false);
            this.tabpLogin.PerformLayout();
            this.tabpAddrbook.ResumeLayout(false);
            this.tabpAddrbook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcMain;
        private System.Windows.Forms.TabPage tabpLogin;
        private System.Windows.Forms.TabPage tabpAddrbook;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Button btnLoginSubmit;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLoginClear;
        private System.Windows.Forms.CheckBox cbLoginRemember;
        private System.Windows.Forms.CheckBox cbLoginDefault;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TabPage tabpSendSms;
        private System.Windows.Forms.CheckBox cbABSelectAll;
        private System.Windows.Forms.Label lblABMessage;
        private System.Windows.Forms.Label lblABList;
        private System.Windows.Forms.Button btnABClear;
        private System.Windows.Forms.RichTextBox rtbABMsg;
        private System.Windows.Forms.Button btnABSend;
        private System.Windows.Forms.CheckedListBox clbABList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}