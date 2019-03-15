using System;
using Way2SmsApp.Google;
using Way2SmsApp.Way2Sms;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GoogleContacts gc = new GoogleContacts("id", "pass");

                // gc.GetContacts();

                //List<ConciseContact> ccList = gc.GetContactsWithBirthdaysToday();

                //ContactCleaner.CleanseContacts(ccList);

                Way2SmsAPI w2sAPI = new Way2SmsAPI("9999999999", "ffsf");

                // For testing
                //w2sAPI.SendSms("9920999713", "Happy birthday !! " + "friend" + " " + "From: Sender");

                bool Addr = w2sAPI.GetAddressBook();

                //"9999999999"
                //foreach (ConciseContact cc in ccList)
                //{
                //    if(cc.IsValidPhone)
                //        w2sAPI.SendSms(cc.PhoneNumber, "Happy birthday !! " + cc.AddressingName + " " + "From: Munish Goyal");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
