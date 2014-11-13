using System;
using System.Collections.Generic;
using DMBelt.Model.Character.Modules;

namespace DMBelt.Model.Character
{
    interface IModuleFactory
    {
        IModule CreateModule();
        IModule CreateModule(string property);
        IModule CreateModule(IModule copy);
    }

    public class ModuleFactory
    {
        //  Fields
        private Dictionary<string, IModuleFactory> s_factories;
        private static ModuleFactory s_instance = new ModuleFactory();

        private ModuleFactory()
        {
            s_factories = new Dictionary<string, IModuleFactory>();

            //  Add Character Module Factories
            s_factories.Add("ProfileModule", new ProfileModuleFactory());
            s_factories.Add("RaceModule", new RaceModuleFactory());
            s_factories.Add("ClassModule", new ClassModuleFactory());
            s_factories.Add("AbilityModule", new AbilityModuleFactory());
            s_factories.Add("HealthModule", new HealthModuleFactory());
            s_factories.Add("SkillModule", new SkillModuleFactory());
            s_factories.Add("FeatModule", new FeatModuleFactory());
            s_factories.Add("PreparedSpellModule", new PreparedSpellModuleFactory());
            s_factories.Add("EquipmentModule", new EquipmentModuleFactory());
            s_factories.Add("ItemModule", new ItemModuleFactory());
        }

        public static IModule CreateModule(string name)
        {
            return s_instance.s_factories[name].CreateModule();
        }

        public static IModule CreateModule(string name, string property)
        {
            return s_instance.s_factories[name].CreateModule(property);
        }

        public static IModule CreateModule(string name, IModule copy)
        {
            return s_instance.s_factories[name].CreateModule(copy);
        }
    }
}
