﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo
{

    public partial class GetUserDTO
    {
        public Data Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class Data
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Avatar { get; set; }
    }

    public partial class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }

}



