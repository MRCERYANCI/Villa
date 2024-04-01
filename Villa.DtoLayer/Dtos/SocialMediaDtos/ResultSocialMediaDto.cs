﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.DtoLayer.Dtos.SocialMediaDtos
{
    public class ResultSocialMediaDto
    {
        public ObjectId Id { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
