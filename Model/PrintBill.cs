using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStoreManage.Model
{
    public class PrintBill
    {

        public String Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public PrintBill()
        {

        }
        public PrintBill(string name, int amount, float price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }
    }
}
