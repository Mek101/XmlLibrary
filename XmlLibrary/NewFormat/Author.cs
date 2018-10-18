using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace XmlLibrary.NewFormat
{
    class Author
    {
        [System.Xml.Serialization.XmlElement(ElementName = "name")]
        public string Name;

        [System.Xml.Serialization.XmlElement(ElementName = "surname")]
        public string Surname;
    }
}
