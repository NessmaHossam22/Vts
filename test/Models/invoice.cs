using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class invoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]

        public int UserId { get; set; }
        public double total { get; set; }
        public double totalpay { get; set; }
        public double diCount { get; set; }
        public virtual Users User { get; set; }
        public virtual List<invoiceDetlies> InvoiceDetlies { get; set; }=new List<invoiceDetlies>();
        
        

    }  public class invoiceDetlies
    {
        [Key]
        public int Id { get; set; }
        public string itemname { get; set; }
        [ForeignKey("item")]
        public int itemId { get; set; }

        public double price { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
        [ForeignKey("invoice")]
        public int invoiceId { get; set; }
        public virtual invoice invoice { get; set; }
        public virtual Item item { get; set; }


    }
}
