using System.Collections.Generic;
//using Way2Sms;

namespace Way2SmsApp.Google
{
    public class ContactCleaner
    {
        public static void CleanseContacts(List<ConciseContact> ccList)
        {
            foreach (ConciseContact cc in ccList)
            {
                // Name
                if (!string.IsNullOrEmpty(cc.Title))
                {
                    cc.AddressingName = cc.Title;
                    cc.IsValidName = true;
                } 
                else if (!string.IsNullOrEmpty(cc.FirstName))
                {
                    cc.AddressingName = cc.FirstName;

                    if (!string.IsNullOrEmpty(cc.LastName))
                    {
                        cc.AddressingName += " " + cc.LastName;
                    }

                    cc.IsValidName = true;
                }
                

                if (!string.IsNullOrEmpty(cc.PhoneNumber))
                {
                    // Phone Number
                    string cleanPhone = cc.PhoneNumber.Replace("-", "");

                    if (cleanPhone.StartsWith("+91"))
                    {
                        if (cleanPhone.Length >= 12)
                            cleanPhone = cleanPhone.Replace("+91", "");
                        else
                            cleanPhone = cleanPhone.Replace("+", "");
                    }
                    else if (cleanPhone.StartsWith("0"))
                    {
                        cleanPhone = cleanPhone.Replace("0", "");
                    }

                    cc.PhoneNumber = cleanPhone;

                    if (cleanPhone.Length == 10)
                        cc.IsValidPhone = true;
                }

            }
        }

    }
}
