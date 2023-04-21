using DateNightSelector.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateNightSelector.Models
{
    public class Dates
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public bool Completed { get; set; }
        public string AddedBy { get; set; }
        public int DateId { get; set; }
    }
}
