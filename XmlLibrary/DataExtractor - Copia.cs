using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace XmlLibrary
{
    class DataExtractor
    {
        XDocument[] _documents;

        public DataExtractor(XDocument[] documentsSource)
        {
            _documents = documentsSource;
        }


        /// <summary>
        /// Retursn all the titles from the given author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public string[] GetTitleByAuthor(string author)
        {
            IEnumerable<string> authors = from doc in _documents
                                          where doc.Element("autore").Element("nome").Value == author
                                          select doc.Element("titolo").Value;

            return authors.ToArray<string>();

        }

    }
}