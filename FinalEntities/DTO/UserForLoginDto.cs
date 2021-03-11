using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEntities.DTO
{
    public class UserForLoginDto:IDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
