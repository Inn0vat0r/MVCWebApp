using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class CommentData
    {
        public String profileimagelink
        {
            get;
            set;
            }
        public String name
        {
            get;
            set;
        }
        public String commenttext
        {
            get;
            set;
        }
        public String commentimagelink
        {
            get;
            set;
        }
        public String user_masterid
        {
            get;
            set;
        }
        public String timestamp
        {
            get;
            set;
        }
    }
}