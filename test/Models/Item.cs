using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        
        public int quanity { get; set; }
        [ForeignKey("mainitem")]
        public int mainitemId { get; set; }
        public virtual mainitem mainitem { get; set; }

    }
}
