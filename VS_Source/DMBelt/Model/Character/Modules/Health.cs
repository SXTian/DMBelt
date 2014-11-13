using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class HealthModule : IModule
    {
        //  Constructor
        public HealthModule()
        {
            ModuleName = "HealthModule";
        }
        public HealthModule(int baseHP, bool dying = false, int tempHP = 0, int wounds = 0, int nonlethal = 0)
        {
            ModuleName = "HealthModule";
            BaseHP = baseHP;
            Dying = dying;
            TempHP = tempHP;
            Wounds = wounds;
            Nonlethal = nonlethal;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public bool Dying { get; set; }
        [XmlAttribute]
        public int BaseHP { get; set; }
        [XmlAttribute]
        public int TempHP { get; set; }
        [XmlAttribute]
        public int Wounds { get; set; }
        [XmlAttribute]
        public int Nonlethal { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Dying":
                    return Dying;

                case "BaseHP":
                    return BaseHP;

                case "TempHP":
                    return TempHP;

                case "Wounds":
                    return Wounds;

                case "Nonlethal":
                    return Nonlethal;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Race': " + property);
                    return null;
            }
        }

        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Dying":
                    Dying = (bool)value;
                    break;

                case "BaseHP":
                    BaseHP = (int)value;
                    break;

                case "TempHP":
                    TempHP = (int)value;
                    break;

                case "Wounds":
                    Wounds = (int)value;
                    break;

                case "Nonlethal":
                    Nonlethal = (int)value;
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
    class HealthModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new HealthModule();
        }
        public IModule CreateModule(string property)
        {
            return new HealthModule();
        }
        public IModule CreateModule(IModule module)
        {
            HealthModule copy = module as HealthModule;
            return new HealthModule(copy.BaseHP, copy.Dying, copy.TempHP, copy.Wounds, copy.Nonlethal);
        }
    }
}
