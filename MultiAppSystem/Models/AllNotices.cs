using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class AllNotices
    {
       public List<NoticeData> allposts_data
        {
            get;
            set;
        }
        public int app_id
        {
            get;
            set;
        }
        public String app_name
        {
            get;
            set;
        }
        public String app_desc
        {
            get;
            set;
        }
    }
}