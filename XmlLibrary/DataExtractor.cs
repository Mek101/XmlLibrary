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


        /// <summary>
        /// Returns the number of copies of the given book
        /// </summary>
        /// <returns></returns>
        public uint GetCopiesBytitle(string title)
        {
            uint copies = 0;

            var thsDck = from doc in _documents
                         where doc.Element("titolo").Value == title
                         select new { copies = copies++, doc.NextNode };

            return copies;
        }


        /// <summary>
        /// Returns the number of 
        /// </summary>
        /// <returns></returns>
        public uint GetNumberByGivenGenere(string genere)
        {
            uint copies = 0;

            var thsDck = from doc in _documents
                         where doc.Element("genere").Value == genere
                         select new { copies = copies++, doc.NextNode };

            return copies;
        }


        /// <summary>
        /// Removes the abstract tag and contenent from the document
        /// </summary>
        public void RemoveAbstract()
        {
            var useless = from doc in _documents
                          select doc.Element("abstract").Remove();
        }


    }
}