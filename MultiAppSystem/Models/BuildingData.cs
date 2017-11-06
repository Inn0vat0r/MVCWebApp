using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiAppSystem.Models
{
    public class BuildingData
    {
        public List<String> building_name
        {
            get;
            set;
        }
        public int belongs_to
        {
            get;
            set;
        }
        public int floor_count
        {
            get;
            set;
        }
        public int flats_perfloor
        {
            get;
            set;
        }
        public int wing_count
        {
            get;
            set;
        }
        public List<String> wing_names
        {
            get;
            set;
        }
        public List<ProjectData> projectstructure
        {
            get;
            set;
        }
    }
}