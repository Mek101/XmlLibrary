using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace XmlLibrary.OldFormat
{
    class Wiride
    {
        [System.Xml.Serialization.XmlElement(ElementName = "titolo")]
        public Title Title;

        [XmlElement(ElementName = "autore")]
        public Author Author;

        [XmlElement(ElementName = "dati_amminisrativi")]
        public AmministrativeData AmministrativeData ;

    }
}