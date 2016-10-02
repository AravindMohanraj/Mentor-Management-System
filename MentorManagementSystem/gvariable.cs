using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MentorManagementSystem
{
    static class Global
    {
       public static  string gvstaffid;
       public static string gvstaffname;
       public static string umode;
       public static string utime;
       

        public static string staffid
        {
            get { return gvstaffid; }
            set { gvstaffid = value; }
        }
        public static string staffname
        {
            get { return gvstaffname; }
            set { gvstaffname = value; }
        }
        public static string mode
        {
            get { return umode ; }
            set { umode = value; }
        }
        public static string ltime
        {
            get { return utime; }
            set { utime = value; }
        }
    }
}