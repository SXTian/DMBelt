using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace DMBelt.Model.Character.Modules
{
    public class AbilityModule : IModule
    {
        //  Constructor
        public AbilityModule()
        {
            ModuleName = "AbilityModule";
        }

        public AbilityModule(string abilityName, int score = 10)
        {
            ModuleName = "AbilityModule";
            Ability = abilityName;
            Score = score;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Ability { get; set; }
        [XmlAttribute]
        public int Score { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Ability":
                    return Ability;

                case "Score":
                    return Score;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Ability': " + property);
                    return null;
            }
        }
        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Ability":
                    Ability = (string)value;
                    break;

                case "Score":
                    Score = (int)value;
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
    class AbilityModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new AbilityModule();
        }
        public IModule CreateModule(string abilityName)
        {
            return new AbilityModule(abilityName);
        }
        public IModule CreateModule(IModule module)
        {
            AbilityModule copy = module as AbilityModule;
            return new AbilityModule(copy.Ability, copy.Score);
        }
    }
}
