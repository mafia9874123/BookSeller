using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Lib.Models
{
   public class Order
    {
        [XmlElement(ElementName = "ISBNCode")]
        public string ISBNCode { get; set; }
        [XmlElement(ElementName = "StoreID")]
        public string StoreID { get; set; }
        [XmlElement(ElementName = "ContactEmail")]
        public string ContactEmail { get; set; }
    }
}
