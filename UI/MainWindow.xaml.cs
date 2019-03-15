using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Way2SmsApp.Core;
using Way2SmsApp.Utils;

namespace Way2SmsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MSG_APP_WELCOME = "Welcome! Please enter inputs and click Submit. After that you can close this window.";
        string MSG_APP_PROCESSING = "Processing! Please wait...";
        string MSG_APP_ERROR_INPUT = "Error: Please dont leave any input box empty";

        string MSG_USER_SMS_DEFAULT = "Happy Birthday !! ";
        string MSG_USER_SIGNATURE_DEFAULT = "From: ";


        UserData _ud;

        public MainWindow()
        {
            InitializeComponent();

            label9.Content = MSG_APP_WELCOME;
            label9.IsEnabled = true;

            // Read userdata from serilaize store


            //Open the file written above and read values from it.
            try
            {
                using (FileStream stream = File.Open(AppConfig.UdStoreFile, FileMode.Open))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    _ud = (UserData)bformatter.Deserialize(stream);
                }
            }
            catch
            {
                _ud = new UserData();
            }

            textBox1.Text = _ud._w2s_id;
            passwordBox1.Password = _ud._w2s_pwd;
            textBox3.Text = _ud._goog_id;
            passwordBox2.Password = _ud._goog_pwd;
            textBox5.Text = _ud._msg;
            textBox6.Text = _ud._signature;

            checkBox4.IsChecked = _ud._isRemember;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!(!string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(passwordBox1.Password) &&
                !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(passwordBox2.Password) &&
                !string.IsNullOrEmpty(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text)))
            {
                label9.Content = MSG_APP_ERROR_INPUT;
                label9.IsEnabled = true;
            }
            else
            {
                label9.Content = MSG_APP_PROCESSING;
                

                _ud._w2s_id = textBox1.Text;
                _ud._w2s_pwd = passwordBox1.Password;
                _ud._goog_id = textBox3.Text;
                _ud._goog_pwd = passwordBox2.Password;
                _ud._msg = textBox5.Text;
                _ud._signature = textBox6.Text;

                _ud._isRemember = checkBox4.IsChecked.Value;

                UserData newUd = null;
                if (checkBox4.IsChecked.Value)
                {
                    // Fill in the user data
                    newUd = _ud;
                }
                else
                {
                    // Clear out the stored data
                    newUd = new UserData();

                    newUd._msg = _ud._msg;
                    newUd._signature = _ud._signature;
                }

                // Serialize user data
                using (Stream stream = File.Open(AppConfig.UdStoreFile, FileMode.Create))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, newUd);
                }


                //AddressBook.
                // Run the app in a new thread
                //ParameterizedThreadStart pts = new ParameterizedThreadStart(SmsSender.SendWishes1);
                //Thread th = new Thread(pts);

                //th.Start(_ud);
            }

            label9.Content = MSG_APP_WELCOME;
        }

        // Clear all UI fields
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
            passwordBox1.Clear();
            textBox3.Clear();
            passwordBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();

            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox4.IsChecked = false;

            label9.Content = MSG_APP_WELCOME;
            label9.IsEnabled = true;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            textBox5.Text = MSG_USER_SMS_DEFAULT;
            textBox5.IsEnabled = false;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox5.IsEnabled = true;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            textBox6.Text = MSG_USER_SIGNATURE_DEFAULT;
            textBox6.IsEnabled = false;
        }

        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox6.IsEnabled = true;
        }
    }
}
