using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Title
    {
        [System.Xml.Serialization.XmlElement(ElementName = "proprio")]
        public string Own;

        [System.Xml.Serialization.XmlElement(ElementName = "responsabilita")]
        public string Responsability;
    }
}