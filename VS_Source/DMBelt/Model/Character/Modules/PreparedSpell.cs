using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class PreparedSpellModule : IModule
    {
        //  Constructor
        public PreparedSpellModule()
        {
            ModuleName = "PreparedSpellModule";
        }
        public PreparedSpellModule(string spell, int level = 0, int quantity = 0, string metamagic = "")
        {
            ModuleName = "PreparedSpellModule";
            Spell = spell;
            Level = level;
            Quantity = quantity;
            Metamagic = metamagic;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Spell { get; set; }
        [XmlAttribute]
        public int Level { get; set; }
        [XmlAttribute]
        public int Quantity { get; set; }
        [XmlAttribute]
        public string Metamagic { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Spell":
                    return Spell;

                case "Level":
                    return Level;

                case "Quantity":
                    return Quantity;

                case "Metamagic":
                    return Metamagic;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Race': " + property);
                    return null;
            }
        }

        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Spell":
                    Spell = (string)value;
                    break;

                case "Level":
                    Level = (int)value;
                    break;

                case "Quantity":
                    Quantity = (int)value;
                    break;

                case "Metamagic":
                    Metamagic = (string)value;
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
    class PreparedSpellModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new PreparedSpellModule();
        }
        public IModule CreateModule(string spell)
        {
            return new PreparedSpellModule(spell);
        }
        public IModule CreateModule(IModule module)
        {
            PreparedSpellModule copy = module as PreparedSpellModule;
            return new PreparedSpellModule(copy.Spell, copy.Level, copy.Quantity, copy.Metamagic);
        }
    }
}
