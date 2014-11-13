using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class FeatModule : IModule
    {
        //  Constructor
        public FeatModule()
        {
            ModuleName = "FeatModule";
        }
        public FeatModule(string feat, string qualifier = "")
        {
            ModuleName = "FeatModule";
            Feat = feat;
            Qualifier = qualifier;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Feat { get; set; }
        [XmlAttribute]
        public string Qualifier { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Feat":
                    return Feat;

                case "Qualifier":
                    return Qualifier;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Class': " + property);
                    return null;
            }
        }
        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Feat":
                    Feat = (string)value;
                    break;

                case "Qualifier":
                    Qualifier = (string)value;
                    break;

                default:
                    break;
            }
        }

        //  Export into Character Properties
        public List<Object> Export()
        {
            List<Object> export = new List<Object>();
            return export;
        }
    }

    //  Concrete Factory
    class FeatModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new FeatModule();
        }
        public IModule CreateModule(string feat)
        {
            return new FeatModule(feat);
        }
        public IModule CreateModule(IModule module)
        {
            FeatModule copy = module as FeatModule;
            return new FeatModule(copy.Feat, copy.Qualifier);
        }
    }
}
