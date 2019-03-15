using System;
using System.Collections.Generic;
using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using Google.GData.Extensions;
using Way2SmsApp.Utils;

namespace Way2SmsApp.Google
{
    public class ConciseContact
    {
        public string FirstName;
        public string LastName;
        public string Title;
        public string PhoneNumber;

        public bool IsValidName;
        public bool IsValidPhone;

        public string AddressingName;
    }

    public class GoogleContacts
    {

        public string ApplicationName = "Way2SmsApp";
        public string userName = "munish.goyal";
        public string passWord = "";

        public GoogleContacts(string user, string pwd)
        {
            userName = user;
            passWord = pwd;
        }

        public void GetContacts()
        {
            RequestSettings rs = new RequestSettings(this.ApplicationName, this.userName, this.passWord);
            // AutoPaging results in automatic paging in order to retrieve all contacts
            rs.AutoPaging = true;
            ContactsRequest cr = new ContactsRequest(rs);

            Feed<Contact> f = cr.GetContacts();
            foreach (Contact entry in f.Entries)
            {
                if (entry.Name != null)
                {
                    Name name = entry.Name;
                    if (!string.IsNullOrEmpty(name.FullName))
                        Console.WriteLine("\t\t" + name.FullName);
                    else
                        Console.WriteLine("\t\t (no full name found)");
                    if (!string.IsNullOrEmpty(name.NamePrefix))
                        Console.WriteLine("\t\t" + name.NamePrefix);
                    else
                        Console.WriteLine("\t\t (no name prefix found)");
                    if (!string.IsNullOrEmpty(name.GivenName))
                    {
                        string givenNameToDisplay = name.GivenName;
                        if (!string.IsNullOrEmpty(name.GivenNamePhonetics))
                            givenNameToDisplay += " (" + name.GivenNamePhonetics + ")";
                        Console.WriteLine("\t\t" + givenNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no given name found)");
                    if (!string.IsNullOrEmpty(name.AdditionalName))
                    {
                        string additionalNameToDisplay = name.AdditionalName;
                        if (string.IsNullOrEmpty(name.AdditionalNamePhonetics))
                            additionalNameToDisplay += " (" + name.AdditionalNamePhonetics
                      + ")";
                        Console.WriteLine("\t\t" + additionalNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no additional name found)");
                    if (!string.IsNullOrEmpty(name.FamilyName))
                    {
                        string familyNameToDisplay = name.FamilyName;
                        if (!string.IsNullOrEmpty(name.FamilyNamePhonetics))
                            familyNameToDisplay += " (" + name.FamilyNamePhonetics + ")";
                        Console.WriteLine("\t\t" + familyNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no family name found)");
                    if (!string.IsNullOrEmpty(name.NameSuffix))
                        Console.WriteLine("\t\t" + name.NameSuffix);
                    else
                        Console.WriteLine("\t\t (no name suffix found)");
                }
                else
                    Console.WriteLine("\t (no name found)");

                foreach (EMail email in entry.Emails)
                {
                    Console.WriteLine("\t" + email.Address);
                }
            }
        }

        public bool AreContactsModifiedToday()
        {
            bool areContactsModifiedToday = false;

            try
            {
                RequestSettings rs = new RequestSettings(this.ApplicationName, this.userName, this.passWord);
                // AutoPaging results in automatic paging in order to retrieve all contacts
                rs.AutoPaging = true;
                ContactsRequest cr = new ContactsRequest(rs);

                ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
                //query.StartDate = new DateTime(2000, 1, 1);
                query.NumberToRetrieve = int.MaxValue;
                //query.OrderBy = 

                query.StartDate = DateTime.Now.AddDays(-1);

                List<ConciseContact> ccList = new List<ConciseContact>();
                DateTime today = DateTime.Now.Date;

                Feed<Contact> feed = cr.Get<Contact>(query);

                if (feed.TotalResults > 0)
                    areContactsModifiedToday = true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return areContactsModifiedToday;
        }


        public List<ConciseContact> GetContactsWithBirthdaysToday()
        {
            RequestSettings rs = new RequestSettings(this.ApplicationName, this.userName, this.passWord);
            // AutoPaging results in automatic paging in order to retrieve all contacts
            rs.AutoPaging = true;
            ContactsRequest cr = new ContactsRequest(rs);

            ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
            query.StartDate = new DateTime(2000, 1, 1);
            query.NumberToRetrieve = int.MaxValue;
            //query.OrderBy = 

            query.ModifiedSince = DateTime.Now.AddDays(-10000);

            List<ConciseContact> ccList = new List<ConciseContact>();
            DateTime today = DateTime.Now.Date;

            Feed<Contact> feed = cr.Get<Contact>(query);
            Contact dbgC = null;
            foreach (Contact c in feed.Entries)
            {
                try
                {
                    dbgC = c;

                    if (string.IsNullOrEmpty(c.ContactEntry.Birthday))
                        continue;

                    DateTime birthday = DateTime.Parse(c.ContactEntry.Birthday);

                    if (birthday.Month != today.Month || birthday.Day != today.Day)
                        continue;

                    // Birthdays today found
                    ConciseContact cc = new ConciseContact();
                    cc.FirstName = c.Name.GivenName;
                    cc.LastName = c.Name.FamilyName;

                    if (c.Organizations.Count > 0)
                        cc.Title = c.Organizations[0].Title;

                    //c.PrimaryPhonenumber
                    //c.PrimaryPhonenumber
                    //c.Phonenumbers[0]
                    if (c.Phonenumbers.Count > 0)
                        cc.PhoneNumber = c.Phonenumbers[0].Value;

                    ccList.Add(cc);

                    Console.WriteLine(c.Title);
                    Console.WriteLine("Name: " + c.Name.FullName);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, dbgC.Name.GivenName + " " + dbgC.Name.FamilyName);
                }
            }

            return ccList;
        }
    }
}
