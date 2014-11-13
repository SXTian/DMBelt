using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBelt.Model.Character
{
    public class ModuleCollector
    {
        //  Properties for accessing Single Modules
        public IModule Profile { get; set; }
        public IModule Race { get; set; }
        public IModule Class { get; set; }
        public IModule Health { get; set; }

        //  Properties for accessing Module Collections
        public HashSet<IModule> Abilities { get; private set; }
        public HashSet<IModule> Skills { get; private set; }
        public HashSet<IModule> Feats { get; private set; }
        public HashSet<IModule> PreparedSpells { get; private set; }
        public HashSet<IModule> Equipment { get; private set; }
        public HashSet<IModule> Items { get; private set; }

        //  Constructor
        public ModuleCollector()
        {
            Abilities = new HashSet<IModule>();
            Skills = new HashSet<IModule>();
            Feats = new HashSet<IModule>();
            PreparedSpells = new HashSet<IModule>();
            Equipment = new HashSet<IModule>();
            Items = new HashSet<IModule>();
        }

        public ModuleCollector(ModuleCollector copy)
        {
            Profile = ModuleFactory.CreateModule("ProfileModule", copy.Profile);
            Race = ModuleFactory.CreateModule("RaceModule", copy.Race);
            Class = ModuleFactory.CreateModule("ClassModule", copy.Class);
            Health = ModuleFactory.CreateModule("HealthModule", copy.Health);
            Abilities = DeepCopy("AbilityModule", copy.Abilities);
            Skills = DeepCopy("SkillModule", copy.Skills);
            Feats = DeepCopy("FeatModule", copy.Feats);
            PreparedSpells = DeepCopy("PreparedSpellModule", copy.PreparedSpells);
            Equipment = DeepCopy("EquipmentModule", copy.Equipment);
            Items = DeepCopy("ItemModule", copy.Items);
        }

        //  Get list of modules
        public HashSet<IModule> GetModuleList()
        {
            HashSet<IModule> collection = new HashSet<IModule>();
            collection.Add(Profile);
            collection.Add(Race);
            collection.Add(Class);
            collection.Add(Health);
            collection.Concat(Abilities);
            collection.Concat(Skills);
            collection.Concat(Feats);
            collection.Concat(PreparedSpells);
            collection.Concat(Equipment);
            collection.Concat(Items);
            return collection;
        }

        public IModule GetAbilityModule(string ability)
        {
            foreach (IModule module in Abilities)
            {
                if ((string)module.GetProperty("Ability") == ability)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("AbilityModule", ability);
            Abilities.Add(newModule);
            return newModule;
        }
     
        public IModule GetSkillModule(string skill)
        {
            foreach (IModule module in Skills)
            {
                if ((string)module.GetProperty("Skill") == skill)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("SkillModule", skill);
            Skills.Add(newModule);
            return newModule;
        }
      
        public IModule GetFeatModule(string feat, string qualifier)
        {
            foreach (IModule module in Feats)
            {
                if ((string)module.GetProperty("Feat") == feat && (string)module.GetProperty("Qualifier") == qualifier)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("FeatModule", feat);
            newModule.SetProperty("Qualifier", qualifier);
            Feats.Add(newModule);
            return newModule;
        }
  

        public IModule GetPreparedSpellModule(string spell, string metamagic)
        {
            foreach (IModule module in PreparedSpells)
            {
                if ((string)module.GetProperty("Spell") == spell && (string)module.GetProperty("Metamagic") == metamagic)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("SpellModule", spell);
            newModule.SetProperty("Metamagic", metamagic);
            PreparedSpells.Add(newModule);
            return newModule;
        }


        public IModule GetEquipmentModule(string slot)
        {
            foreach (IModule module in Equipment)
            {
                if ((string)module.GetProperty("Slot") == slot)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("EquipmentModule", slot);
            Skills.Add(newModule);
            return newModule;
        }


        public IModule GetItemModule(string item, int enhancement, string material)
        {
            foreach (IModule module in Items)
            {
                if ((string)module.GetProperty("Item") == item && (int)module.GetProperty("Enhancement") == enhancement && (string)module.GetProperty("Material") == material)
                    return module;
            }
            IModule newModule = ModuleFactory.CreateModule("ItemModule", item);
            newModule.SetProperty("Enhancement", enhancement);
            newModule.SetProperty("Material", material);
            Items.Add(newModule);
            return newModule;
        }

        public void AddModule(IModule module)
        {
            switch (module.ModuleName)
            {
                case "ProfileModule":
                    Profile = module;
                    break;
                case "RaceModule":
                    Race = module;
                    break;
                case "ClassModule":
                    Class = module;
                    break;
                case "HealthModule":
                    Health = module;
                    break;
                case "AbilityModule":
                    Abilities.Add(module);
                    break;
                case "SkillModule":
                    Skills.Add(module);
                    break;
                case "FeatModule":
                    Feats.Add(module);
                    break;
                case "PreparedSpellModule":
                    PreparedSpells.Add(module);
                    break;
                case "EquipmentModule":
                    Equipment.Add(module);
                    break;
                case "ItemModule":
                    Items.Add(module);
                    break;
            }
        }
        HashSet<IModule> DeepCopy(string moduleName, HashSet<IModule> copy)
        {
            HashSet<IModule> result = new HashSet<IModule>();
            foreach (IModule module in copy)
            {
                result.Add(ModuleFactory.CreateModule(moduleName, module));
            }
            return result;
        }
    }
}
