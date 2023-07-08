using System;

namespace DTO.DTOs.ContactDtos
{
    public class ContactListDto
    {
        public int ID { get; set; }

        public string NameSurname { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
