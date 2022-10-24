using System;
using System.IO;

namespace ActionAtaDistance1.Logging
{
    public class CoreEventLog
    {
        public static bool EnableLogging = false;    
        public static string IP_Address { get; set; }

        #region LogEvent to database - not used in this demo

        public static void LogEvent(string Action, string Table_name, long? Record_id, string Message, bool Error)
        {
            if (EnableLogging == false)
            {
                return;
            }

            Model.EventLog event_log = new Model.EventLog
            {
                App = App.Name,
                AppVersion = App.Version,
                UserName = Environment.UserName,
                MachineName = Environment.MachineName,
                IP_Address = IP_Address,
                TableName = Table_name,
                RecordID = Record_id,
                Message = Message,
                Error = Error,
                RecordsReturned = null,
                ActionDateTime = DateTime.Now,
                ActionTaken = Action
            };
        }

        public static void LogEvent(string Action)
        {
            if (EnableLogging == false)
            {
                return;
            }
            LogEvent(Action, null, null, null, false);
        }

        public static void LogEvent(string Action, string Message)
        {
            if (EnableLogging == false)
            {
                return;
            }
            LogEvent(Action, null, null, Message);
        }

        public static void LogEvent(string Action, string Table_name, long? Record_id, string Message)
        {
            if (EnableLogging == false)
            {
                return;
            }
            LogEvent(Action, Table_name, Record_id, Message, false);
        }

        #endregion

        public static void WriteToLogFile(string Action)
        {
            WriteToLogFile(Action, null, null, null, null);
        }

        public static void WriteToLogFile(string Action, string Table_name, long? Record_id, string Message, bool? Error)
        {
            if (EnableLogging == false)
            {
                return;
            }

            using (var log_file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\CoreEvent.log", true))
            {
                log_file.WriteLine();
                log_file.WriteLine("AppName: {0}", App.Name);
                log_file.WriteLine("AppVersion: {0}", App.Version);
                log_file.WriteLine("AppName: {0}", Environment.UserName);
                log_file.WriteLine("MachineName: {0}", Environment.MachineName);
                log_file.WriteLine("IP_Address: {0}", IP_Address);
                log_file.WriteLine("ActionDateTime: {0}", DateTime.Now);
                log_file.WriteLine("ActionTaken: {0}", Action);
                if (Table_name != null) log_file.WriteLine("TableName: {0}", Table_name);
                if (Record_id != null) log_file.WriteLine("RecordID: {0}", Record_id);
                if (Message != null) log_file.WriteLine("tSQL: {0}", Message);
                if (Error != null) log_file.WriteLine("ErrorMessage: {0}", Error);
                log_file.Flush();
            }

        }
    }
}
