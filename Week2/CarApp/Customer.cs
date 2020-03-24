using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    class Customer :IPerson
    {

        private string name;
        private string tel;
        private string uid;
        private bool isExistingCustomerd;

        public string Name { get =>name; set => name = value; }
        public string Tel { get =>tel; set=> tel = value; }

        public string Uid { get =>uid; set => uid = value; }

        public bool IsExistingCustomer { get => isExistingCustomerd ; set => isExistingCustomerd = value; }

        public Customer()
        {
            IsExistingCustomer = false;
        }

        public Customer(string name, string tel, string uid, bool isExisting = false)
        {
            Name = name;
            Tel = tel;
            Uid = uid;
            IsExistingCustomer = isExisting;
            
        }
    }
}
