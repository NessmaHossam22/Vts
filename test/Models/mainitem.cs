using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class mainitem
    {
        [Key]
        public int id { get; set; }
        public string Nmae { get; set; }
        public virtual List<Item> Items { get; set; }=new List<Item>();

    }
}
