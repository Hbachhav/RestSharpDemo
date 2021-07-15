using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo.DTO
{
    class UpdateUserDTO
    {
        
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

