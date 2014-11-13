using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class RaceModule : IModule
    {
        //  Constructor
        public RaceModule()
        {
            ModuleName = "RaceModule";
        }
        public RaceModule(string race)
        {
            ModuleName = "RaceModule";
            Race = race;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Race { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Race":
                    return Race;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Race': " + property);
                    return null;
            }
        }

        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Race":
                    Race = (string)value;
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
    class RaceModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new RaceModule();
        }
        public IModule CreateModule(string race)
        {
            return new RaceModule(race);
        }
        public IModule CreateModule(IModule module)
        {
            RaceModule copy = module as RaceModule;
            return new RaceModule(copy.Race);
        }
    }
}
