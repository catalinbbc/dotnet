using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedShoppingCartAfter
{
    class OrderItemSpecial : OrderItem
    {
        public override decimal TotalAmount()
        {
            decimal total = 0m;
            // $0.40 each; 3 for a $1.00
            total = this.Quantity * .4m;
            int setsOfThree = this.Quantity / 3;
            total -= setsOfThree * .2m;

            return total;
        }
    }
}
