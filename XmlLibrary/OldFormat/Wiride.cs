using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace XmlLibrary.OldFormat
{
    class Wiride
    {
        [System.Xml.Serialization.XmlElement(ElementName = "codice_scheda")]
        public string FormCode;

        [System.Xml.Serialization.XmlElement(ElementName = "codice_deway")]
        public string DewayCode;

        [System.Xml.Serialization.XmlElement(ElementName = "titolo")]
        public string Title;

        [System.Xml.Serialization.XmlElement(ElementName = "autore")]
        public Author Author;

        [System.Xml.Serialization.XmlElement(ElementName = "abstract")]
        public string Description;

        [System.Xml.Serialization.XmlElement(ElementName = "genere")]
        public string Category;

        [System.Xml.Serialization.XmlElement(ElementName = "tipo_materiale")]
        public string FormatType;
    }
}