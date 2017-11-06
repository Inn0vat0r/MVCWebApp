using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class AllAppDetails
    {
       public int app_id
        {
            get;
            set;
        }
        public int app_type
        {
            get;
            set;
        }
        public int app_subtype
        {
            get;
            set;
        }
        public string app_name
        {
            get;
            set;
        }
        public string app_desc
        {
            get;
            set;
        }
        public string invite_code
        {
            get;
            set;
        }
        public string app_splashlink
       
        {
            get;
            set;
        }
        public string app_placeid
        {
            get;
            set;
        }
        public string app_placename
        {
            get;
            set;
        }
        public double app_latitude
        {
            get;
            set;
        }
        public double app_longitude
        {
            get;
            set;
        }
        public Boolean isPrivate
        {
            get;
            set;
        }

    }
}