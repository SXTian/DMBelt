using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class SkillModule : IModule
    {
        //  Constructor
        public SkillModule()
        {
            ModuleName = "SkillModule";
        }
        public SkillModule(string skill, int rank = 0)
        {
            ModuleName = "SkillModule";
            Skill = skill;
            Rank = rank;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Skill { get; set; }
        [XmlAttribute]
        public int Rank { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Skill":
                    return Skill;

                case "Rank":
                    return Rank;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Ability': " + property);
                    return null;
            }
        }
        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Skill":
                    Skill = (string)value;
                    break;

                case "Rank":
                    Rank = (int)value;
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
    class SkillModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new SkillModule();
        }
        public IModule CreateModule(string property)
        {
            return new SkillModule(property);
        }
        public IModule CreateModule(IModule module)
        {
            SkillModule copy = module as SkillModule;
            return new SkillModule(copy.Skill, copy.Rank);
        }
    }
}
