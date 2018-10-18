using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Edition
    {
        [System.Xml.Serialization.XmlElement(ElementName = "ed_indicazione")]
        public string Indication;

        [System.Xml.Serialization.XmlElement(ElementName = "ed_responsabilita")]
        public string Responsability;
    }
}