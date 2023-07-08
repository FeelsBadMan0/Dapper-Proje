using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Visitors")]
    public class Visitor
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string RePassword { get; set; }
        public virtual bool RememberMe { get; set; }
    }
}
