// DZ220530 - Train
//
// Version : 1.0
// Release : June 16/2022
//
// Re : EventLog Reader




using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;



namespace WindowsLog

{

    public class ReadEventLog

    {
        static void Main()
        {
            Console.WriteLine("Main");

            Console.WriteLine("App = [{0}]", app);
            //Console.WriteLine("AppName = [{0}]", AppName);

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                //eventLog.Source = "DaniilApp";
                eventLog.WriteEntry("Daniil Log message example", EventLogEntryType.Information, 101, 1);
            }

            ReadApplicationLog();
            try
            {
                int a = 1;
                a = a / 0;
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    //eventLog.Source = "DaniilApp";
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                }
                Console.WriteLine("Error [{0}]", ex.Message);
                Console.ReadLine();
            }

            Console.WriteLine("Done");
            Console.ReadLine();


        }

        static string app = "Application";

        //public static  string AppName
        //{
        //    get { };
        //    set { };
        //}

        public static void ReadApplicationLog()
        {
            // logType can be an Application, Security, System, or

            // any other Custom Log.

            string applicationlog = app;

            string mymachine = ".";   // local machine

            //EventLog myapplicationLog = new EventLog(applicationlog, mymachine);
            EventLog myapplicationLog = new EventLog("application", mymachine);

            EventLogEntryCollection entries = myapplicationLog.Entries;

            int LogCount = entries.Count;

            if (LogCount <= 0)
                Console.WriteLine("No Event Logs in the Log :" +
                  applicationlog);

            Console.WriteLine("Reading " + applicationlog + "Log");

            foreach (EventLogEntry entry in entries)
            {
                Console.WriteLine("################################");

                Console.WriteLine("Log Level: {0}", entry.EntryType);
                Console.WriteLine("Log Event id: {0}",

                   entry.InstanceId);

                Console.WriteLine("Log Message: {0}", entry.Message);
                Console.WriteLine("Log Source: {0}", entry.Source);
                Console.WriteLine("Entry Date: {0}",

                   entry.TimeGenerated);

                Console.WriteLine("################################");



            }

            Console.WriteLine("Finished Reading " + applicationlog + "Log");

        }



    }

}