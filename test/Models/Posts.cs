using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Posts
    {
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }
}