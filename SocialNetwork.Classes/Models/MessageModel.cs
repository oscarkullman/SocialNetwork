﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Classes.Models
{
    public class MessageModel
    {
        public string? Sender {  get; set; }

        public string? Reciever { get; set; }

        public string? Content { get; set; }
    }
}
