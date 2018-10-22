using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlLibrary.NewFormat
{
    class LibraryFormat
    {
        [System.Xml.Serialization.XmlElement(ElementName = "barcode")]
        public string Barcode;

        [System.Xml.Serialization.XmlElement(ElementName = "title")]
        public string Title;

        [System.Xml.Serialization.XmlElement(ElementName = "subject")]
        public string Subject;

        [System.Xml.Serialization.XmlElement(ElementName = "description")]
        public string Description;

        [System.Xml.Serialization.XmlElement(ElementName = "category")]
        public string Category;

        [System.Xml.Serialization.XmlElement(ElementName = "key_words")]
        public string[] KeyWords;
    }
}
