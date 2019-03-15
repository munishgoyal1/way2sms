using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Way2SmsApp.Google;
using Way2SmsApp.Utils;
using Way2SmsApp.Way2Sms;

namespace Way2SmsApp.Core
{
    public class SmsSender
    {

        public static void SendWishes1(object o)
        {
            string todayDate = string.Empty;
            try
            {
                // First check if todays wishes are done.
                todayDate = DateTime.Now.Date.ToShortDateString().Replace('/', '-');
                string todayFileName = Path.Combine(AppConfig.GreetingsDir, todayDate);

                Logger.LogIt("Started SendWishes for " + todayDate);
                
                GreetingsData gd;

                if (!File.Exists(todayFileName))
                {
                    gd = new GreetingsData();
                }
                else
                {
                    using (FileStream stream = File.Open(todayFileName, FileMode.Open))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();

                        gd = (GreetingsData)bformatter.Deserialize(stream);
                    }
                }

                // If some wishes are pending then only do it , else return for the day

                UserData ud;

                //Open the file written above and read values from it.

                // User data
                using (FileStream stream = File.Open(AppConfig.UdStoreFile, FileMode.Open))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();
                    ud = (UserData)bformatter.Deserialize(stream);
                }

                GoogleContacts gc = new GoogleContacts(ud._goog_id, ud._goog_pwd);
                if (!gd.IsAllDone || gc.AreContactsModifiedToday())
                {
                    // Wishes
                    SendWishes(ud, gd);

                    // Check gd
                    if (gd.TotalCount == gd.DoneCount)
                    {
                        gd.IsAllDone = true;
                    }

                    // Now write back the gd
                    using (FileStream ws = File.Open(todayFileName, FileMode.Create))
                    {
                        BinaryFormatter bformatter = new BinaryFormatter();
                        bformatter.Serialize(ws, gd);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, ex.Message);
            }

            Logger.LogIt("Ended SendWishes for " + todayDate);
        }

        public static void SendWishes(UserData ud, GreetingsData gd)
        {
            GoogleContacts gc = new GoogleContacts(ud._goog_id, ud._goog_pwd);

            // gc.GetContacts();

            List<ConciseContact> ccList = gc.GetContactsWithBirthdaysToday();

            ContactCleaner.CleanseContacts(ccList);

            Logger.LogIt("Fetched List of birthdays today. Count = " + ccList.Count);

            Way2SmsAPI w2sAPI = new Way2SmsAPI(ud._w2s_id, ud._w2s_pwd);

            // For testing
            //app.SendSms("9999999999", "Dear ....." + "Happy birthday !! " + " " + "~~ From: Munish Goyal ~~");

            foreach (ConciseContact cc in ccList)
            {
                if (cc.IsValidPhone)
                {
                    ContactData cd = null;
                    if (!gd.WishTable.TryGetValue(cc.PhoneNumber, out cd))
                    {
                        cd = new ContactData(cc);
                        gd.WishTable.Add(cc.PhoneNumber, cd);
                        gd.TotalCount++;
                    }
                    
                    if(!cd.isWished)
                    {
                        if (w2sAPI.SendSms(cc.PhoneNumber, ud._msg + cc.AddressingName + " " + ud._signature))
                        {
                            Logger.LogIt("Wished " + cc.AddressingName + " at " + cc.PhoneNumber);
                            cd.isWished = true;
                            gd.DoneCount++;
                        }
                    }
                }
            }


        }
    }
}
