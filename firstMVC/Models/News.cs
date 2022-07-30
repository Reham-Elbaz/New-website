using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVC.Models
{
    public class News
    {
        public int Id { get; set; }
        [DisplayName("Title of the news")]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }
        
        [ForeignKey("Category")] //not mandatory line
        public int CategoryId { get; set; }  //to put foreignkey(by default that's enough but if it doesn't work we use the previous line)
        public Category Category { get; set; }  //for one relationship
    }
}
