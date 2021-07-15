using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo
{

    public partial class CreateUserDTO
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }


}


   

