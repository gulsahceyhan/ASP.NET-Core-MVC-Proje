﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concrete
{
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }

        public int ProductID { get; set; }  
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        
        
        //public virtual Product Product { get; set; }
    }
}
