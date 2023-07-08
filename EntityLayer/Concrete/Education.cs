using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Educations")]
    public class Education
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string GNOT { get; set; }

        public string Date { get; set; }
    }
}
