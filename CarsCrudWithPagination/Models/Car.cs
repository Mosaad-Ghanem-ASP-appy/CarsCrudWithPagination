using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCrudWithPagination.Models
{
    public class Car
    {
        [Key]
        [Display(Name = "Cars No")]
        public int CarNo { get; set; }
        [Display(Name = "User No")]
        public string UserNo { get; set; }
        [Display(Name = "Ar Name")]
        public string ArName { get; set; }
        [Display(Name = "En Name")]
        public string EnName { get; set; }
        [Display(Name = "Card No")]
        public string CardNo { get; set; }
        [Display(Name = "Begin Date")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Company { get; set; }

        [ForeignKey(nameof(Color))]
        public int ColorNo { get; set; }
        public Colors? Color { get; set; }

        public string Model { get; set; }

    }
}
