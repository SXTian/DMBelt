using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.IO;
using DMBelt.Model.Character;

namespace DMBelt.DataAccess
{
    //  Singleton Module Serializer
    public class ModuleSerializer
    {
        //  Fields
        private static ModuleSerializer s_instance = new ModuleSerializer();

        //  Constructor
        private ModuleSerializer()
        {
        }

        //  Deserialize a module
        public static IModule ReadModule(string name, string innerXML)
        {
            IModule module = ModuleFactory.CreateModule(name);
            System.Type type = module.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            module = (IModule)serializer.Deserialize(new StringReader(innerXML));
            return module;
        }

        //  Serialize a list of modules
        public static void WriteModule(IModule module, XmlWriter writer)
        {
            System.Type type = module.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, module, ns);
        }
    }
}
