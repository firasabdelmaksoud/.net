using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Rdv
    {
        public int id { get; set; }

        public String Debut_rdv { get; set; }
        public String Fin_rdv { get; set; }
        public String description { get; set; }
    }
}