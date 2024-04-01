using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Contact : BaseEntity
    {
        public string MapUrl { get; set; }  //Harita Yolu Sutunü
        public string Phone { get; set; }   //Telefon Numarası Sutunü
        public string Email { get; set; }   //Mail Adresi Sutunü
        public string Adress { get; set; }   //Mail Adresi Sutunü
    }
}
