using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Shop.Product
{
    public class ProductPriceCalculator
    {
        public long SetItemPrice(int multiplyer, long price)
        {
            float res = price * multiplyer;
            res *= multiplyer;

            return (long)res;
        }
    }
}
