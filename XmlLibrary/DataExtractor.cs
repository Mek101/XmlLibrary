using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace XmlLibrary
{
    class DataExtractor
    {
        private const string PATH = @"..\..\";
        XElement[] _documents;

        public DataExtractor(XDocument documentsSource)
        {
            _documents = documentsSource.Descendants("Bibliotca").ToArray();
        }


        /// <summary>
        /// Retursn all the titles from the given author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public string[] GetTitleByAuthor(string author)
        {
            IEnumerable<string> authors = from doc in _documents
                                          where doc.Element("wiride").Element("autore").Element("nome").Value == author
                                          select doc.Element("wiride").Element("titolo").Value;

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
                         where doc.Element("wiride").Element("titolo").Value == title
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
            IEnumerable<XNode> temp = from doc in _documents
                                      where doc.Element("wiride").Element("abstract").Value != null
                                      select doc;

            foreach (XNode n in temp)
                n.Remove();
        }


        /// <summary>
        /// Changes the genere of the given book
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genere"></param>
        public void ChangeGenereByTitle(string title, string genere)
        {
            var veryUsefulVar = from doc in _documents
                                where doc.Element("wiride").Element("titolo").Value == title
                                select doc.Element("wiride").Element("genere").Value = genere;
        }



        public void MakeSubset()
        {
            // Create a new Xml document
            XDocument newFormat = new XDocument(new XElement("biblioteca"));

            // Creates the nodes
            IEnumerable<XElement> nodes = from book in _documents
                                          select new XElement(
                                              new XElement("libro",
                                                  new XElement("codice_scheda", book.Element("wiride").Element("codice_scheda").Value),
                                                  new XElement("titolo", book.Element("wiride").Element("titolo").Value),
                                                  new XElement("cognome_autore", book.Element("wiride").Element("autore").Element("cognome").Value)
                                              )
                                           );

            // Adds the nodes
            newFormat.Root.AddFirst(nodes.ToArray());

            // Saves the xml document with an asyncronous task
            //new Task(delegate()
            //{
                newFormat.Save(PATH + "libriShort.xml")
            //});
        }

    }
}