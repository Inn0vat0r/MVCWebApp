using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class ProjectData
    {
        public String project_name
        {
            get;
            set;
        }
    }
    public class ProjectDataOutput
    {
        public String project_name
        {
            get;
            set;
        }
        public int project_code
        {
            get;
            set;
        }
    }
}