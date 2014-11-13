using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class ClassModule : IModule
    {
        //  Constructor
        public ClassModule()
        {
            ModuleName = "ClassModule";
        }
        public ClassModule(string className, int level = 1, int experience = 0)
        {
            ModuleName = "ClassModule";
            Class = className;
            Level = level;
            Experience = experience;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Class { get; set; }
        [XmlAttribute]
        public int Level { get; set; }
        [XmlAttribute]
        public int Experience { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Class":
                    return Class;

                case "Level":
                    return Level;

                case "Experience":
                    return Experience;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Class': " + property);
                    return null;
            }
        }
        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Class":
                    Class = (string)value;
                    break;

                case "Level":
                    Level = (int)value;
                    break;

                case "Experience":
                    Experience = (int)value;
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
    class ClassModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new ClassModule();
        }
        public IModule CreateModule(string className)
        {
            return new ClassModule(className);
        }
        public IModule CreateModule(IModule module)
        {
            ClassModule copy = module as ClassModule;
            return new ClassModule(copy.Class, copy.Level, copy.Experience);
        }
    }
}
