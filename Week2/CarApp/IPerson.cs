using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    interface IPerson
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Uid { get; set; }
        public bool IsExistingCustomer { get; set; }

    }
}
