using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class NoticeData
    {
        public int app_id
        {
            get;
            set;
        }
      public  int notice_id
        {
            get;
            set;
        }
        public String user_name
        {
            get;
            set;
        }
        public String user_imglink
        {
            get;
            set;
        }
        public String noticetext
        {
            get;
            set;
        }
        public int commentCount
        {
            get;
            set;
        }
        public String last_active
        {
            get;
            set;
        }
        //public List<String> postimages
        //{
        //    get;
        //    set;
        //}

    }
}