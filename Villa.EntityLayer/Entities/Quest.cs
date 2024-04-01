using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Quest : BaseEntity
    {
        public string Question { get; set; }  //Soru Sutünü
        public string Answer { get; set; }  //Cevap Sutünü
    }
}
