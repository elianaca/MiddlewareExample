using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpOldWay
{
    /// <summary>
    /// Summary description for CalendarHandler
    /// </summary>
    public class CalendarHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string message = context.Request.QueryString["message"];

            if (!string.IsNullOrEmpty(message))
            {
                context.Response.ContentType = "text/calendar";  
                context.Response.AddHeader("Content-disposition", "attachment; filename=email.ics");
                context.Response.Write(GetiCal(message));
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

#region not important code
        string GetiCal(string message)
        {

            DateTime startDate = DateTime.Now.AddHours(-12);
            DateTime endDate = DateTime.Now.AddHours(-6);
            string location = "ONLINE";

            StringBuilder sbBody = new StringBuilder();
            string description = @"The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men. Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is the Lord when I lay My vengeance upon thee.\\n" + sbBody.ToString();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("PRODID:-//MDE.NET demo//NONSGML HttpOldWay//EN");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("METHOD:PUBLISH");

            sb.AppendLine("BEGIN:VTIMEZONE");
            sb.AppendLine("TZID:Eastern Standard Time");
            sb.AppendLine("BEGIN:STANDARD");
            sb.AppendLine("RRULE:FREQ=YEARLY;BYDAY=1SU;BYMONTH=11");
            sb.AppendLine("TZOFFSETFROM:-0400");
            sb.AppendLine("TZOFFSETTO:-0500");
            sb.AppendLine("END:STANDARD");
            sb.AppendLine("BEGIN:DAYLIGHT");
            sb.AppendLine("RRULE:FREQ=YEARLY;BYDAY=2SU;BYMONTH=3");
            sb.AppendLine("END:DAYLIGHT");
            sb.AppendLine("END:VTIMEZONE");
            sb.AppendLine("BEGIN:VEVENT");
            sb.AppendLine("CLASS:PUBLIC");
            sb.AppendFormat("CREATED:{0}\n", DateTime.Now.ToString(DateFormat));
            sb.AppendFormat("DESCRIPTION:{0}", description);
            sb.AppendFormat("\nDTEND:{0}", endDate.ToString(DateFormat));
            sb.AppendFormat("DTSTAMP:{0}\n", DateTime.Now.ToString(DateFormat));
            sb.AppendFormat("DTSTART:{0}", startDate.ToString(DateFormat));
            sb.AppendFormat("\nLOCATION:{0}", location);
            sb.AppendLine("\nPRIORITY:5");
            sb.AppendFormat("SEQUENCE:{0}", 0);
            sb.AppendFormat("\nSUMMARY;LANGUAGE=en-us:{0}\n", message);
            sb.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:Tentative");
            sb.AppendLine("X-MICROSOFT-CDO-IMPORTANCE:1");
            sb.AppendLine("X-MICROSOFT-DISALLOW-COUNTER:FALSE");
            sb.AppendLine("X-MS-OLK-AUTOFILLLOCATION:FALSE");
            sb.AppendLine("X-MS-OLK-CONFTYPE:0");
            sb.AppendLine("BEGIN:VALARM");
            sb.AppendLine("TRIGGER:-PT15M");
            sb.AppendLine("ACTION:DISPLAY");
            sb.AppendLine("DESCRIPTION:Reminder");
            sb.AppendLine("END:VALARM");
            sb.AppendLine("END:VEVENT");
            sb.AppendLine("END:VCALENDAR");

            return sb.ToString();
        }

        private string DateFormat
        {
            get
            {
                return "yyyyMMddTHHmmssZ"; // 20130215T092000Z
            }
        }
#endregion
    }
}