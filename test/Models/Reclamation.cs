using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Reclamation
    {
        [Key]
        public int id { get; set; }
        public String Reason { get; set; }
        public String Detail { get; set; }
        [Column(TypeName = "date")]
        public DateTime dateofcreation { get; set; }
        public String State { get; set; }
        public virtual List<Parents> Parent { get; set; }
        public virtual List<ChildrenGarden> ChildrenGardens { get; set; }
    }
}