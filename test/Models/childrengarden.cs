using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using test.Models;
namespace test.Models
{
    public class ChildrenGarden
    {
		[Key]
		public int id { get; set; }
		public String description { get; set; }
		public String nom { get; set; }
		[Column(TypeName = "date")]
		public DateTime Creation_Date { get; set; }
		public String location { get; set; }
		public String photo { get; set; }
		public int phone_number { get; set; }
		public int price { get; set; }
		public virtual ICollection<Activity> activities { get; set; }
		public virtual ICollection<Reclamation> reclamations { get; set; }
		public virtual ICollection<Rdv> Rdvs { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }
		public virtual ICollection<Events> events { get; set; }
		public virtual Messaging message { get; set; }
	}
}