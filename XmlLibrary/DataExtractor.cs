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
        private const string PATH = @"..\..\..\";

        private const string NEW_FILE = "libriNew.xml";
        private const string SHORT_FILE = "libriShort.xml";

        private const string ROOT_NAME = "Biblioteca";


        // Collection of XElements to work and query on
        XElement[] _xElements;

        public DataExtractor(XDocument documentsSource)
        {
            // Extracts all the elements now to increase efficency
            _xElements = documentsSource.Descendants(ROOT_NAME).ToArray();
        }


        /// <summary>
        /// Retursn all the titles from the given author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public string[] GetTitleByAuthor(string author)
        {
            author = author.ToLower();

            // Extracts all the authors
            IEnumerable<string> authors = from elem in _xElements
                                          where elem.Element("wiride").Element("autore").Element("nome").Value.ToLower() == author
                                          select elem.Element("wiride").Element("titolo").Value;

            // Returns an array with the authors
            return authors.ToArray<string>();
        }


        /// <summary>
        /// Returns the number of copies of the given book
        /// </summary>
        /// <returns></returns>
        public uint GetCopiesBytitle(string title)
        {
            title = title.ToLower();

            IEnumerable<object> collector = from elem in _xElements
                                            where elem.Element("wiride").Element("titolo").Value.ToLower() == title
                                            select elem;

            return (uint)collector.Count();
        }


        /// <summary>
        /// Returns the number of books with the given genre.
        /// </summary>
        /// <returns>The number of authors.</returns>
        public uint GetNumberByGivenGenre(string genre)
        {
            genre = genre.ToLower();

            IEnumerable<object> collector = from elem in _xElements
                                            where elem.Element("wiride").Element("genere").Value.ToLower() == genre
                                            select elem;

            return (uint)collector.Count();
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
            foreach (XElement element in _xElements)
                element.Descendants("wiride").Descendants("abstract").Remove();


            // Also this, it's not Linq too but is --SHOULD-- work...
            //_xElements.Elements<XElement>().Where(elem => elem.Name == "abstract").Remove();
        }


        /// <summary>
        /// Changes the genre of the given book.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <param name="genre">Genre to set.</param>
        public void ChangeGenreByTitle(string title, string genre)
        {
            title = title.ToLower();

            var veryUsefulVar = from elem in _xElements
                                where elem.Element("titolo").Value.ToLower() == title
                                select elem.Element("genere").Value = genre;
        }



        /// <summary>
        /// Creates a subset and saves them in a new file
        /// </summary>
        public void MakeSubset() { MakeSubset(Path.Combine(PATH, SHORT_FILE)); }

        /// <summary>
        /// Creates a subset and saves them in a new file
        /// </summary>
        public bool MakeSubset(string path)
        {
            // Create a new Xml document
            XDocument newFormat = new XDocument(new XElement("biblioteca"));

            // Creates a collection with the nodes
            IEnumerable<XElement> nodes = from book in _xElements
                                          select new XElement(
                                              new XElement("libro",
                                                  new XElement("codice_scheda", book.Element("wiride").Element("codice_scheda").Value),
                                                  new XElement("titolo", book.Element("wiride").Element("titolo").Value),
                                                  new XElement("cognome_autore", book.Element("wiride").Element("autore").Element("cognome").Value)
                                              )
                                           );

            // Adds the nodes in the root
            newFormat.Root.AddFirst(nodes.ToArray());

            return SaveFile(path, newFormat);
        }


        public void SaveDocument() { SaveDocument(Path.Combine(PATH, NEW_FILE)); }

        /// <summary>
        /// Saves on disk the current document
        /// </summary>
        /// <param name="path">Path to save the file. Uses the default value if empty.</param>
        public bool SaveDocument(string path)
        {
            return SaveFile(path, MakeDocument());
        }


        // Writes the document on the list
        private bool SaveFile(string path, XDocument document)
        {
            try
            {
                document.Save(Path.Combine(path));
                return true;

            }
            catch(Exception e)
            {
                return false;
            }
        }


        private XDocument MakeDocument()
        {
            XDocument doc = new XDocument(new XElement(ROOT_NAME));
            doc.Root.AddFirst(_xElements);

            return doc;
        }


        public string Dump()
        {
            return MakeDocument().ToString();
        }

    }
}