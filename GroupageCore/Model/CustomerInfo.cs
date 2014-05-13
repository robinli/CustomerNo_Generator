using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupageCore.Model
{
    public class CustomerDB
    {
        public List<CustomerInfo> Items = new List<CustomerInfo>();
    }

    public class CustomerInfo
    {
        public string Customer_Code { get; set; }

        public string Customer_Name { get; set; }

        public string Prefix { get; set; }

        public string New_Code { get; set; }

    }
}
