using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCrudWithPagination.Models
{
    public class Colors
    {
        [Key]
        public int ColorNo { get; set; }
        public string ColorName { get; set; }

    }
}
