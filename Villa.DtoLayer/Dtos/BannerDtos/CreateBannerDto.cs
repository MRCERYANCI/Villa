using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.DtoLayer.Dtos.BannerDtos
{
    public class CreateBannerDto
    {
        public string City { get; set; }  //Şehir Sütünü
        public string Title { get; set; }  //Başlık Sütünü
        public string Country { get; set; }  //Ülke Sütünü   
    }
}
