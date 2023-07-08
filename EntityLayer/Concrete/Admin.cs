using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Admins")]
    public class Admin
    {

        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string AdminRoles { get; set; }
        public virtual bool RememberMe { get; set; }
    }
}
