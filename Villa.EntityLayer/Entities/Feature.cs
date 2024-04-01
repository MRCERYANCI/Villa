using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Feature : BaseEntity
    {
        public string ImageUrl { get; set; }  //Resim Yolu Sutünü
        public string Title { get; set; }   //Başlık Sutünü
        public string SubTitle { get; set; }  //Alt Başlık Sutünü
        public string Square { get; set; }   //Metrekare Sutünü
        public string Contract { get; set; }  //Kontrat Sutünü
        public string Payment { get; set; }   //Ödeme Sutünü
        public string Safety { get; set; }   //Güvenlik Sütünü
    }
}
