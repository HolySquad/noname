using System.ComponentModel.DataAnnotations;

namespace WebLayer.Models
{
    public class SearchModel
    {
        [Display(Name = "Search")]
        public string Query { get; set; }     
    }
}