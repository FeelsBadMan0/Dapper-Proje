using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Contacts")]
    public class Contact
    {

        public int ID { get; set; }

        public string NameSurname { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
