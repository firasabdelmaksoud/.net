using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test.Models;

namespace test.Models
{
    public class Participation
    {
        [Key]
        public int id { get; set; }
        public virtual Parents parent { get; set; }
        public virtual ICollection<Events> events { get; set; }
    }
}
