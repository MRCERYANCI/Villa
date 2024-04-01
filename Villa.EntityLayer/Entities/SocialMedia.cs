using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public bool status { get; set; } = false;
    }
}
