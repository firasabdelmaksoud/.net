using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace test.Models
{
    public class Activity
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public double prix { get; set; }

    }
}