﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.DtoLayer.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string Name { get; set; }  
        public string Email { get; set; }  
        public string Subject { get; set; } 
        public string MessageContact { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get => DateTime.Now; }
    }
}
