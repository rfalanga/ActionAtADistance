using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionAtaDistance1.Model;

namespace ActionAtaDistance1.Logging
{
    public class CoreEventLog
    {
        public static bool EnableLogging = false;

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

        public static string IP_Address { get; set; }
    }
}
