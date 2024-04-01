using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Product : BaseEntity
    {
        public string ImageUrl { get; set; } //Resim Yolu Sutunü
        public string Category { get; set; }  //Kategori Sutunü
        public string Price { get; set; }  //Fiyat Sutunü
        public string Title { get; set; }  //Başlık Sutunü
        public int BedRoomCount { get; set; }  //Oda Sayısı Sutunü
        public int BathRoomCount { get; set; }  //Banyo Sayısı Sutunü
        public int Area { get; set; }  //MetreKare Sutunü
        public int Floor { get; set; }
        public int ParkingCount { get; set; }  //Park Sayısı Sutunü
    }
}
