using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using DMBelt.Model.Character;

namespace DMBelt.DataAccess
{
    /// <summary>
    /// Represents the data collection  of Characters in the application.
    /// </summary>
    public class CharacterRepository
    {
        //  Fields
        string m_characterFilePath;
        readonly HashSet<Character> m_characters;

        //  Constructor

        /// <summary>
        /// Creates a new repository of Characters.
        /// </summary>
        /// <param name="filePath">The relative path to an XML file that contains the Character data.</param>
        public CharacterRepository(string filePath)
        {
            m_characterFilePath = filePath;
            m_characters = LoadCharacters();
        }

        //  Public Interface

        /// <summary>
        /// Raised when a Character is placed into the repository.
        /// </summary>
        public event EventHandler<CharacterAddedEventArgs> CharacterAdded;
        public event EventHandler<CharacterDeletedEventArgs> CharacterDeleted;

        /// <summary>
        /// Adds a Character into the repository.
        /// </summary>
        public void AddCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException("Character");

            if (!m_characters.Contains(character))
            {
                m_characters.Add(character);

                if (CharacterAdded != null)
                    CharacterAdded(this, new CharacterAddedEventArgs(character));
            }
        }
        public void DeleteCharacter(Character character, CharacterDeletedEventArgs e)
        {
            if (m_characters.Contains(character))
            {
                m_characters.Remove(character);

                if (CharacterDeleted != null)
                    CharacterDeleted(this, e);
            }

        }
        /// <summary>
        /// Saves the current repository.
        /// </summary>
        public void Save()
        {
            CreateEmptyFile();
            foreach (Character character in m_characters)
                SaveCharacter(character);
        }

        private void CreateEmptyFile()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.InsertBefore(xdoc.CreateXmlDeclaration("1.0", "utf-8", null), xdoc.DocumentElement);
            xdoc.AppendChild(xdoc.CreateElement("Characters"));
            xdoc.Save(m_characterFilePath);
        }

        /// <summary>
        /// Returns true if the Character exists in the
        /// repository, or false if it does not.
        /// </summary>
        public bool ContainsCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException("Character");

            return m_characters.Contains(character);
        }

        /// <summary>
        /// Returns a list of all Characters in the repository.
        /// </summary>
        public HashSet<Character> GetCharacters()
        {
            return new HashSet<Character>(m_characters);
        }

        //  Private Helpers
        private HashSet<Character> LoadCharacters()
        {
            //  Get each Character XElement
            HashSet<Character> characterList = new HashSet<Character>();
            XElement root = XElement.Load(m_characterFilePath);
            IEnumerable<XElement> characters = from character in root.Elements("Character")
                                               select character;

            //  Add the appropriate modules filled with deserialized data
            foreach (XElement character in characters)
            {
                Character newCharacter = new Character();
                IEnumerable<XElement> elements = character.Elements();

                foreach (XElement module in elements)
                    newCharacter.Modules.AddModule(ModuleSerializer.ReadModule(module.Name.ToString(), module.ToString()));

                characterList.Add(newCharacter);
            }
            return characterList;
        }

        private void SaveCharacter(Character character)
        {
            //  To get contents of Modules as XML strings, I need to pipe my XmlWriter to a StringBuilder
            StringBuilder output = new StringBuilder();
            StringWriter internalWriter = new StringWriter(output);
            XmlWriter writer = new XmlTextWriter(internalWriter);

            //  Write all of character's Modules into string buffer 'output'
            writer.WriteStartElement("Character");
            foreach (IModule module in character.Modules.GetModuleList())
                ModuleSerializer.WriteModule(module, writer);
            writer.WriteEndElement();

            //  Load up the Character Repository
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(m_characterFilePath);

            //  Puts content of 'output' into a XmlDocumentFragment and appends it the Character Repository
            XmlDocumentFragment xfrag = xdoc.CreateDocumentFragment();
            xfrag.InnerXml = output.ToString();
            xdoc.DocumentElement.AppendChild(xfrag);

            //  Saves the Character Repository
            xdoc.Save(m_characterFilePath);
        }
    }
}