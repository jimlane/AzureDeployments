﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ContosoInventoryAPIApp.Models
{
    [DataContract]
    public class InventoryData
    {
        [DataMember, Key]
        public int partID { get; set; }
        [DataMember]
        public string partName { get; set; }
        [DataMember]
        public string partDescription { get; set; }

    }

    public class vProducts
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductModel { get; set; }
        public int CultureID { get; set; }
        public string Description { get; set; }
    }
}
