using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedShoppingCartAfter
{
    class OrderItemEach : OrderItem
    {
        public override decimal TotalAmount()
        {
            decimal total = 0m;
            total = this.Quantity * 5m;

            return total;
        }
    }
}
