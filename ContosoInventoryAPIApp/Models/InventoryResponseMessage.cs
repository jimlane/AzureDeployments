using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoInventoryAPIApp.Models
{
    public class InventoryResponseMessage
    {
        public InventoryResponseMessage()
        {
            this.Data = new List<InventoryData>();
        }

        public IEnumerable<InventoryData> Data { get; set; }
        public InventoryData Record { get; set; }
    }
}