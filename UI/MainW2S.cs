using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Way2SmsApp.Core;
using Way2SmsApp.Utils;
using Way2SmsApp.Way2Sms;

namespace Way2SmsApp.UI
{
    public partial class MainW2S : Form
    {
        public MainW2S()
        {
            InitializeComponent();
            _ud = new UserData();
        }

        private UserData _ud;
        private Way2SmsAPI w2sAPI;

        private string MSG_APP_WELCOME =
            "Welcome! Login Successful";

        private string MSG_APP_PROCESSING = "Processing! Please wait...";
        private string MSG_APP_ERROR_INPUT = "Error: Please correct the errors before proceeding";

        private string MSG_USER_SMS_DEFAULT = "Happy Birthday !! ";
        private string MSG_USER_SIGNATURE_DEFAULT = "From: ";

        private bool isAddrbookLoaded;
        private bool isLoginDone;

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLogin();

                ValidatePassword();

                // Validate
                if (!string.IsNullOrEmpty(errorProvider1.GetError(tbLogin)) ||
                    !string.IsNullOrEmpty(errorProvider2.GetError(tbPassword)))
                {
                    HandleError(null, MSG_APP_ERROR_INPUT);
                    return;
                }

                // If all conditions have been met, clear the ErrorProvider of errors.
                //errorProvider1.SetError(tbLogin, "");
                //errorProvider2.SetError(tbPassword, "");

                lblLog.Text = MSG_APP_PROCESSING;

                _ud._w2s_id = tbLogin.Text;
                _ud._w2s_pwd = tbPassword.Text;
                _ud._isRemember = cbLoginRemember.Checked;

                if (_ud._isRemember)
                    // Serialize user data
                    using (Stream stream = File.Open(AppConfig.UdStoreFile, FileMode.Create))
                    {
                        var bformatter = new BinaryFormatter();
                        bformatter.Serialize(stream, _ud);
                    }


                //AddressBook.
                // Run the app in a new thread
                //ParameterizedThreadStart pts = new ParameterizedThreadStart(SmsSender.SendWishes1);
                //Thread th = new Thread(pts);

                //th.Start(_ud);
                w2sAPI = new Way2SmsAPI(_ud._w2s_id, _ud._w2s_pwd);
                w2sAPI.Login();
                isLoginDone = true;
                lblLog.Text = MSG_APP_WELCOME;

                tabcMain.SelectedTab = tabpAddrbook;

            }
            catch (Exception ex)
            {
                HandleError(ex, "");
            }
        }

        private void cbLoginDefault_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLoginDefault.Checked)
                {
                    using (FileStream stream = File.Open(AppConfig.UdStoreFile, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        _ud.Copy((UserData) bformatter.Deserialize(stream));
                    }

                    tbLogin.Text = _ud._w2s_id;
                    tbPassword.Text = _ud._w2s_pwd;
                    cbLoginRemember.Checked = _ud._isRemember;
                }
                else
                {
                    tbLogin.Clear();
                    tbPassword.Clear();
                    _ud.Clear();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "");
            }
        }

        private void HandleError(Exception ex, string msg)
        {
            lblLog.Text = ex != null ? ex.Message : "" + " " + msg;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void ValidateLogin()
        {
            if (!W2SUtils.ValidateW2SMobileNumber(tbLogin.Text))
                errorProvider1.SetError(tbLogin, "Invalid Mobile Number");
            else
                errorProvider1.SetError(tbLogin, "");
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void ValidatePassword()
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
                errorProvider2.SetError(tbPassword, "Password cannot be empty");
            else
                errorProvider2.SetError(tbPassword, "");
        }

        private void cbLoginRemember_CheckedChanged(object sender, EventArgs e)
        {
            _ud._isRemember = cbLoginRemember.Checked;
        }

        private void cbABSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cbABSelectAll.Checked)
                for(int i = 0; i < clbABList.Items.Count; i++)
                    clbABList.SetItemChecked(i, true);
            else
                for (int i = 0; i < clbABList.Items.Count; i++)
                    clbABList.SetItemChecked(i, false);
        }

        private void tabcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            if (!isLoginDone)
            {
                tabcMain.SelectedTab = tabpLogin;
                return;
            }

            if (tabcMain.SelectedTab == tabpAddrbook)
                if (!isAddrbookLoaded)
                {
                    w2sAPI.GetAddressBook();
                    clbABList.DataSource = w2sAPI.AddressBook.Contacts.Select(x => x.ToString()).ToList();
                    isAddrbookLoaded = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "");
            }
        }

        private void btnABClear_Click(object sender, EventArgs e)
        {
            rtbABMsg.ResetText();
        }

        private void btnABSend_Click(object sender, EventArgs e)
        {
            ValidateMesageText();
            // Validate
            if (!string.IsNullOrEmpty(errorProvider3.GetError(rtbABMsg)))
            {
                HandleError(null, MSG_APP_ERROR_INPUT);
                return;
            }

            List<string> numbers = new List<string>();

            foreach(var item in clbABList.CheckedItems)
            {
                var parts = item.ToString().Split(' ');
                numbers.Add(parts[parts.Length - 1]);
            }

            foreach (var number in numbers)
                w2sAPI.SendSms(number, rtbABMsg.Text);
        }

        private void rtbABMsg_TextChanged(object sender, EventArgs e)
        {
            ValidateMesageText();
        }

        private void ValidateMesageText()
        {
            if (string.IsNullOrEmpty(rtbABMsg.Text))
                errorProvider3.SetError(rtbABMsg, "Message Text cannot be empty");
            else
                errorProvider3.SetError(rtbABMsg, "");
        }

        //private void tbPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(tbPassword.Text))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(tbPassword, "Password cannot be empty");
        //    }
        //}

        //private void tbPassword_Validated(object sender, EventArgs e)
        //{
        //    // If all conditions have been met, clear the ErrorProvider of errors.
        //    errorProvider1.SetError(tbPassword, "");
        //}

        //private void tbLogin_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!W2SUtils.ValidateW2SMobileNumber(tbLogin.Text))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider2.SetError(tbLogin, "Invalid Mobile Number");
        //    }
        //}

        //private void tbLogin_Validated(object sender, EventArgs e)
        //{
        //    // If all conditions have been met, clear the ErrorProvider of errors.
        //    errorProvider2.SetError(tbLogin, "");
        //}

    }
}
