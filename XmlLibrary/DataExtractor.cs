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
        // Default path to save the file to
        private const string PATH = @"..\..\";

        // Collection of XElements to work and query on
        XElement[] _documents;

        public DataExtractor(XDocument documentsSource)
        {
            // Extracts all the elements now to increase efficency
            _documents = documentsSource.Descendants("biblioteca").ToArray();
        }


        /// <summary>
        /// Retursn all the titles from the given author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public string[] GetTitleByAuthor(string author)
        {
            // Extracts all the authors
            IEnumerable<string> authors = from doc in _documents
                                          where doc.Element("wiride").Element("autore").Element("nome").Value == author
                                          select doc.Element("wiride").Element("titolo").Value;

            // Returns an array with the authors
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
        /// Returns the number of books with the given genre.
        /// </summary>
        /// <returns>The number of authors.</returns>
        public uint GetNumberByGivenGenre(string genre)
        {
            uint copies = 0;

            var thsDck = from doc in _documents
                         where doc.Element("genere").Value == genre
                         select new { copies = copies++, doc.NextNode };

            return copies;
        }


        /// <summary>
        /// Removes the abstract tag and it's contenent from the document.
        /// </summary>
        public void RemoveAbstract()
        {
            /*
            IEnumerable<XNode> temp = from doc in _documents
                                      where doc.Element("wiride").Element("abstract").Value != null
                                      select doc;

            foreach (XNode node in temp)
                node.Remove();
             */
            
            // Not Linq but is --SHOULD-- work...
            foreach (XElement element in _documents)
                element.Descendants("wiride").Descendants("abstract").Remove();
        }


        /// <summary>
        /// Changes the genre of the given book.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <param name="genre">Genre to set.</param>
        public void ChangeGenreByTitle(string title, string genre)
        {
            var veryUsefulVar = from doc in _documents
                                where doc.Element("wiride").Element("titolo").Value == title
                                select doc.Element("wiride").Element("genere").Value = genre;
        }


        /// <summary>
        /// Creates a subset and saves them in a new file
        /// </summary>
        public void MakeSubset()
        {
            // Create a new Xml document
            XDocument newFormat = new XDocument(new XElement("biblioteca"));

            // Creates a collection with the nodes
            IEnumerable<XElement> nodes = from book in _documents
                                          select new XElement(
                                              new XElement("libro",
                                                  new XElement("codice_scheda", book.Element("wiride").Element("codice_scheda").Value),
                                                  new XElement("titolo", book.Element("wiride").Element("titolo").Value),
                                                  new XElement("cognome_autore", book.Element("wiride").Element("autore").Element("cognome").Value)
                                              )
                                           );

            // Adds the nodes in the root
            newFormat.Root.AddFirst(nodes.ToArray());

            // Saves the xml document
            newFormat.Save(PATH + "libriShort.xml");
        }

    }
}