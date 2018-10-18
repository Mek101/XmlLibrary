using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlLibrary.NewFormat
{
    class LibraryFormat
    {
        [System.Xml.Serialization.XmlElement(ElementName = "barcode")]
        public uint barcode;

        [System.Xml.Serialization.XmlElement(ElementName = "title")]
        public string title;

        [System.Xml.Serialization.XmlElement(ElementName = "codauthor")]
        public uint codauthor;

        [System.Xml.Serialization.XmlElement(ElementName = "subject")]
        public string subject;

        [System.Xml.Serialization.XmlElement(ElementName = "description")]
        public string description;

        [System.Xml.Serialization.XmlElement(ElementName = "category")]
        public string category;

        [System.Xml.Serialization.XmlElement(ElementName = "media")]
        public string media;

        [System.Xml.Serialization.XmlElement(ElementName = "publisher")]
        public string publisher;

        [System.Xml.Serialization.XmlElement(ElementName = "publocation")]
        public string publocation;

        [System.Xml.Serialization.XmlElement(ElementName = "pubdate")]
        public string pubdate;

        [System.Xml.Serialization.XmlElement(ElementName = "edition")]
        public string edition;

        [System.Xml.Serialization.XmlElement(ElementName = "isbn")]
        public uint isbn;

        [System.Xml.Serialization.XmlElement(ElementName = "callnumber")]
        public uint callnumber;

        [System.Xml.Serialization.XmlElement(ElementName = "keywords")]
        public uint keywords;
    }
}
