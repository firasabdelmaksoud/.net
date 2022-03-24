using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Messaging
    {
		[Key]
		public int id{ get; set; }
		public String sender{ get; set; }
		public String reciever{ get; set; }
		[Column(TypeName = "date")]
		public DateTime date{ get; set; }
		public String description{ get; set; }
		public virtual List<Parents> Parent { get; set; }
		public virtual List<ChildrenGarden> ChildrenGardens { get; set; }

	}
}