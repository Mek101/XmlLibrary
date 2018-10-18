using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Publishing
    {
        [System.Xml.Serialization.XmlElement(ElementName = "editore")]
        public string Publisher;

        [System.Xml.Serialization.XmlElement(ElementName = "cod_editore")]
        public string Code;

        [System.Xml.Serialization.XmlElement(ElementName = "luogo")]
        public string Location;
    }
}