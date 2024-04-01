using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Deal : BaseEntity
    {
        public string Type { get; set; }
        public string ImageUrl { get; set; } //Resim Yolu Sutunü
        public string Title { get; set; } //Başlık Sutunü
        public string Description { get; set; } //Açıklama Sutunü
        public string Square { get; set; }  //MetreKare Sutunü
        public string Floor { get; set; }  //Kaçıncı Kat Olduğu Sutunü
        public string RoomCount { get; set; }  //Oda Sayısı Sutunü
        public bool HasParkingArea { get; set; } //Park Alanı Var mı ? Yok mu ? 
        public string PaymentType { get; set; } //Ödeme Türü Sutunü
    }
}
