﻿using System.Runtime.Serialization;

namespace WebAPITutorial
{
    public class User
    {
        [IgnoreDataMember]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
