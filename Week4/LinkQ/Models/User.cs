﻿using System;
using System.Collections.Generic;

namespace LinqAndLamdaExpressions.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public Company Company { get; set; }

        public static implicit operator List<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}
