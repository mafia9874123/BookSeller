using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lib.Models
{
    public class Book
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "ISBNCode")]
        public string ISBNCode { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}
