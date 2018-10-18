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
        public string ;
        public string Author;

        [XmlElement(ElementName = "dati_amminisrativi")]
        public AmministrativeData AmministrativeData ;

    }
}