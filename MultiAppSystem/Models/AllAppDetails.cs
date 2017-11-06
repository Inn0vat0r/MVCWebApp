using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class allappsdetails
    {
        public AppAdmin app_admin
        {
            get;
            set;
        }
        public AllAppDetails app_details
        {
            get;
            set;
        }
        public int member_count
        {
            get;
            set;
        }
    }
}