using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class ProfileModule : IModule
    {
        //  Constructor
        public ProfileModule()
        {
            ModuleName = "ProfileModule";
            IsPC = true;
            IsFemale = true;
        }
        public ProfileModule(string name, bool isPC = true, bool isFemale = true)
        {
            ModuleName = "ProfileModule";
            Name = name;
            IsPC = isPC;
            IsFemale = isFemale;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool IsPC { get; set; }
        [XmlAttribute]
        public bool IsFemale { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Name":
                    return Name;

                case "IsPC":
                    return IsPC;

                case "IsNPC":
                    return !IsPC;

                case "IsFemale":
                    return IsFemale;

                case "IsMale":
                    return !IsFemale;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Profile': " + property);
                    return null;
            }
        }
        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Name":
                    Name = (string)value;
                    break;

                case "IsPC":
                    IsPC = (bool)value;
                    break;

                case "IsNPC":
                    IsPC = !(bool)value;
                    break;

                case "IsFemale":
                    IsFemale = (bool)value;
                    break;

                case "IsMale":
                    IsFemale = !(bool)value;
                    break;
                default:
                    break;
            }
        }

        //  Export into Character Properties
        public List<Object> Export()
        {
            List<Object> export = new List<Object>();
            export.Add(Name);
            return export;
        }
    }

    //  Concrete Factory
    class ProfileModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new ProfileModule();
        }
        public IModule CreateModule(string name)
        {
            return new ProfileModule(name);
        }
        public IModule CreateModule(IModule module)
        {
            ProfileModule copy = module as ProfileModule;
            return new ProfileModule(copy.Name, copy.IsPC, copy.IsFemale);
        }
    }
}
