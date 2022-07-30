using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }

        //for many relationship
        public List<News> News { get; set; }
    }
}
