using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Description
    {
        [System.Xml.Serialization.XmlElement(ElementName = "pagine_volumi")]
        public uint Pages;
    }
}