using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public class Logic_LoginAndReg
    {
        // check if the user-entered information validates logging in (Matching email and password)
        public static Boolean loginCheck(String email, String password)
        {
            Boolean result = false; ;
            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                StreamReader userFile = new StreamReader("..\\DB\\UserDB.csv");
                Dictionary<string, string> userInfo = new Dictionary<string, string>();
                String[] lineSplit;

                // store all emails and passwords in userInfo
                while (!userFile.EndOfStream)
                {
                    lineSplit = userFile.ReadLine().Split(","); // email, password
                    userInfo.Add(lineSplit[0], lineSplit[1]); // email as key, password as value
                }
                userFile.Close();

                // check if the email exists, then if the password matches
                if (userInfo[email].Equals(password))
                {
                    result = true;
                }

            }

            return result;
        }

        // check if the user-entered information validates register (No duplicate emails)
        public static Boolean registerCheck(String email, String password)
        {
            Boolean result = false;
            if (MailAddress.TryCreate(email, out _))
            {
                StreamReader userFile = File.OpenText("..\\DB\\UserDB.csv");
                HashSet<string> emailList = new HashSet<string>();

                // store all emails in emailList
                while (!userFile.EndOfStream)
                {
                    emailList.Add(userFile.ReadLine().Split(",")[0]);
                }
                userFile.Close();

                // check if the email exists; check returns true if it does not exist
                if (emailList.Contains(email))
                {
                    result = true;
                    StreamWriter fileWriter = File.AppendText("..\\DB\\UserDB.csv");
                    fileWriter.WriteLine(email + "," + password);
                }
            }

            return result;
        }
    }
}
