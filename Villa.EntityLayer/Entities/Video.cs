﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.EntityLayer.Entities
{
    public class Video : BaseEntity
    {
        public string VideoUrl { get; set; }  //Video Yolu Sutünü
        public string CoverImage { get; set; }  //Kapak Resmi
    }
}
