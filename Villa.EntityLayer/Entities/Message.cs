using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Message : BaseEntity
    {
        public string Name { get; set; }  //İsim Sutunü
        public string Email { get; set; }  //Mail Adresi Sutunü
        public string Subject { get; set; }  //Konu Sutunü
        public string MessageContact { get; set; } //Mesaj İçeriği Sutunü
        public string PhoneNumber { get; set; } //Mesaj Telefon Sutunü
        public DateTime CreatedDate { get; set; }
    }
}
