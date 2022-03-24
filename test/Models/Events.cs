using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Events
    {
		[Key]
		public int id { get; set; }
		[Required]
		public String name { get; set; }
		public String description { get; set; }
		[StringValidator(MinLength =10)]
		public int capacity { get; set; }
		[Required]
		public float price { get; set; }
		[Column(TypeName = "date")]
		public DateTime date { get; set; }
		public virtual ChildrenGarden ChildrenGardens { get; set; }
		public virtual List<Participation> participations { get; set; }
	}
}