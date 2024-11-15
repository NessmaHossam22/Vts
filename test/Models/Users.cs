using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string Name  { get; set; }
        public string email  { get; set; }
        public string password  { get; set; }

       
        public virtual List<invoice> invoices { get; set; }
    }
}
