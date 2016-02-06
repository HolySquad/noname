using System.ComponentModel.DataAnnotations;

namespace WebLayer.Models
{
    public class SearchModel
    {
        [Display(Name = "Search")]
        public string SearchString { get; set; }     
    }
}