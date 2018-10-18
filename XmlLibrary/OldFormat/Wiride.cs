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
        public Title Title;

        [System.Xml.Serialization.XmlElement(ElementName = "autore")]
        public Author Author;

        [System.Xml.Serialization.XmlElement(ElementName = "dati_amministrativi")]
        public AmministrativeData AmministrativeData;

        [System.Xml.Serialization.XmlElement(ElementName = "abstract")]
        public Description Description;

        [System.Xml.Serialization.XmlElement(ElementName = "pubblicazione")]
        public Publishing Publishing;

        [System.Xml.Serialization.XmlElement(ElementName = "edizione")]
        public Edition Edition;

        [System.Xml.Serialization.XmlElement(ElementName = "tipo_materiale")]
        public string FormatType;
    }
}