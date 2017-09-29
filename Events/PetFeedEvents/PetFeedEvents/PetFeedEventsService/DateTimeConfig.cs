using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace PetFeedEventsService
{
    public class DateTimeConfig 
    {

        public string RunMethod { get { return (string)ConfigurationManager.AppSettings["RunMethod"]; }   }

        public DateTime StartDate { get { return (DateTime)Convert.ToDateTime(ConfigurationManager.AppSettings["StartDate"]);}  }

        public DateTime EndDate { get { return (DateTime)Convert.ToDateTime(ConfigurationManager.AppSettings["EndDate"]);}  }

        public string RunTime { get { return (string)ConfigurationManager.AppSettings["RunTime"]; }   }

        public DateTime RecordDate { get { return (DateTime)Convert.ToDateTime(ConfigurationManager.AppSettings["RecordDate"]);}   }
    }
}
