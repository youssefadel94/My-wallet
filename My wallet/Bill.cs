using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_wallet
{
   
    public class  Bill
    {
        public int ID { get; set; }

        public int TotalAmount { get; set; }

        public int Amount { get; set; } 

        public string Des { get; set; }
        public int spent { get; set; }
       
    }
}
