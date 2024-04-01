using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Banner : BaseEntity
    {
        public string City { get; set; }  //Şehir Sütünü
        public string Title { get; set; }  //Başlık Sütünü
        public string Country { get; set; }  //ResimYolu Sütünü     
    }
}
