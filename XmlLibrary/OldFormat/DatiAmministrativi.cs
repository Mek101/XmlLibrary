using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlLibrary.OldFormat
{
    class AmministrativeData
    {
        [XmlElement(ElementName = "inventario")]
        public uint Inventory;
        public string Data;
    }
}