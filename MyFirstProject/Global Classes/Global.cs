using Microsoft.Win32;
using ProjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstProject.Global_Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool IsloginBanned()
        {
            string sourceName = "DVLD_APP";
            try
            {
                // If the event source does not exist, then no ban has been logged
                if (!EventLog.SourceExists(sourceName))
                    return false;

                EventLog eventLog = new EventLog("Application");
                DateTime cutoffTime = DateTime.Now.AddHours(-1);

                // Iterate over the log entries in reverse order (newest first)
                for (int i = eventLog.Entries.Count - 1; i >= 0; i--)
                {
                    EventLogEntry entry = eventLog.Entries[i];

                    // Check if the entry is from our source and is within the last hour
                    if (entry.Source == sourceName && entry.TimeGenerated >= cutoffTime)
                    {
                        // Look for our specific error message indicating a ban.
                        if (entry.EntryType == EventLogEntryType.Error &&
                            entry.Message.Contains("User has exceeded all available login attempts"))
                        {
                            return true;
                        }
                    }

                    // Since the entries are in reverse chronological order, break out once we pass the cutoff.
                    if (entry.TimeGenerated < cutoffTime)
                        break;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }





        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDAppInfo";
            string valueName = "CurrentUserinDVLDApp";
            string valueData = $"{Username}#{Password}";
            //string SavedData = clsUtil.ComputeHash(valueData);
            try
            {
                Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool GetStoredCredential(ref string username, ref string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDAppInfo";
            string valueName = "CurrentUserinDVLDApp";

            try
            {
                string value = Registry.GetValue(keyPath, valueName, null) as string;
                if (value == null)
                {
                    return false;
                }
                else
                {
                    string[] currentuser = value.Split('#');

                    username = currentuser[0];
                    password = currentuser[1];

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;


            }
        } 

        //public static bool GetStoredCredential(ref string Username, ref string Password)
        //{
        //    //this will get the stored username and password and will return true if found and false if not found.
        //    try
        //    {
        //        //gets the current project's directory
        //        string currentDirectory = System.IO.Directory.GetCurrentDirectory();

        //        // Path for the file that contains the credential.
        //        string filePath = currentDirectory + "\\data.txt";

        //        // Check if the file exists before attempting to read it
        //        if (File.Exists(filePath))
        //        {
        //            // Create a StreamReader to read from the file
        //            using (StreamReader reader = new StreamReader(filePath))
        //            {
        //                // Read data line by line until the end of the file
        //                string line;
        //                while ((line = reader.ReadLine()) != null)
        //                {
        //                    Console.WriteLine(line); // Output each line of data to the console
        //                    string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

        //                    Username = result[0];
        //                    Password = result[1];
        //                }
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred: {ex.Message}");
        //        return false;
        //    }

        //}
    }
}
