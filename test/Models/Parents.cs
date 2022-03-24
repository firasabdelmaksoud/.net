using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Parents : User
    {
       
        
        public string name { get; set; }
        public string child_name { get; set; }
        public DateTime dateNaissance { get; set; }
        public string photo { get; set; }
        public int phone_number { get; set; }
       
        public string adress { get; set; }
        public string mail { get; set; }
        public User user { get; set; }


        // public List<LikeKinderGarten> likes { get; set; }
        //  public List<object> garden { get; set; }
        // public List<object> reclamations { get; set; }
        //  public List<object> messages { get; set; }
        //  public List<object> post { get; set; }
        // public object satisfaction { get; set; }
        public DateTime date_inscrit { get; set; }
        public string kindergartenname { get; set; }
       // public List<object> feedbacks { get; set; }
       // public List<object> rdvs { get; set; }
    }
}