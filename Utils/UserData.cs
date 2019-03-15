using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Way2SmsApp.Google;

namespace Way2SmsApp.Core
{
    [Serializable()]
    public class GreetingsData
    {
        public bool IsFirstTime = true;
        public bool IsAllDone = false;
        public DateTime Date = DateTime.Now.Date;
        public int DoneCount = 0;
        public int TotalCount = 0;
        public Dictionary<string, ContactData> WishTable = new Dictionary<string,ContactData>();
    }

    [Serializable()]
    public class ContactData
    {
        public ContactData(ConciseContact cc)
        {
            Name = cc.AddressingName;
            Phone = cc.PhoneNumber;
            isWished = false;
        }
        public string Name;
        public string Phone;
        public bool isWished;
    }


    [Serializable()]
    public class UserData
    {
        
        public string _w2s_id;
        public string _w2s_pwd;
        public string _goog_id;
        public string _goog_pwd;

        public string _msg;
        public string _signature;

        public bool _isRemember;

        public UserData()
        {
            _w2s_id = "";
            _w2s_pwd = "";
            _goog_id = "";
            _goog_pwd = "";
            _msg = "";
            _signature = "";
            _isRemember = false;
        }

        //Deserialization constructor.

        public UserData(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties

            _w2s_id = (string)info.GetValue("_w2s_id", typeof(string));
            _w2s_pwd = (string)info.GetValue("_w2s_pwd", typeof(string));
            _goog_id = (string)info.GetValue("_goog_id", typeof(string));
            _goog_pwd = (string)info.GetValue("_goog_pwd", typeof(string));
            _msg = (string)info.GetValue("_msg", typeof(string));
            _signature = (string)info.GetValue("_signature", typeof(string));
            _isRemember = (bool)info.GetValue("_isRemember", typeof(bool));
        }
        
        //Serialization function.

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_w2s_id", _w2s_id);
            info.AddValue("_w2s_pwd", _w2s_pwd);
            info.AddValue("_goog_id", _goog_id);
            info.AddValue("_goog_pwd", _goog_pwd);
            info.AddValue("_msg", _msg);
            info.AddValue("_signature", _signature);
            info.AddValue("_isRemember", _isRemember);
        }
    }
}
