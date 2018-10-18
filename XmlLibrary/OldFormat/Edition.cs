using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Edition
    {
        [System.Xml.Serialization.XmlElement(ElementName = "note_edizione")]
        public string Notes;
    }
}