using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlLibrary.OldFormat
{
    class Author
    {
        [System.Xml.Serialization.XmlElement(ElementName = "nome")]
        public string Name;

        [System.Xml.Serialization.XmlElement(ElementName = "cognome")]
        public string Surname;

        [System.Xml.Serialization.XmlElement(ElementName = "cod_autore")]
        public string Code;

        public string GetFullName() { return Name + " " + Surname; }
    }
}