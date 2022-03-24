using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Matching
    {
        public int id { get; set; }
        public object childrengarden { get; set; }
        public string dateDebutParent { get; set; }
        public string dateFinParent { get; set; }
        public string dateDebutGarden { get; set; }
        public string dateFinGarden { get; set; }
        public string dateDebutMatching { get; set; }
        public string dateFinMatching { get; set; }
        public bool result { get; set; }
        public object parent { get; set; }
    }
}