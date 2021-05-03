using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepUKW.ViewModels
{
    public class ItemRemoveViewModel
    {
        public int itemId { get; set; }

        public int itemQuantity { get; set; }

        public decimal cartValue { get; set; }
    }
}