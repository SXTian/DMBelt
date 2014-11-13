using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DMBelt.Properties;

namespace DMBelt.Model.Character
{
    //  WHY YOU HAVE NO TYPEDEF C#??
    using Property = KeyValuePair<string, CharacterProperty>;

    /// <summary>
    /// Represents a Character.
    /// It contains a dictionary of character properties
    /// and a list of modifiers.
    public class Character
    {
        public Character()
        {
            m_properties = new Dictionary<string, CharacterProperty>();
            m_modifiers = new List<PropertyModifier>();
            Modules = new ModuleCollector();
        }

        public Character(Character copy)
        {
            m_properties = new Dictionary<string, CharacterProperty>(copy.m_properties);
            m_modifiers = new List<PropertyModifier>(copy.m_modifiers);
            Modules = new ModuleCollector(copy.Modules);
        }

        //  Fields
        private Dictionary<string, CharacterProperty> m_properties;
        private List<PropertyModifier> m_modifiers;

        public ModuleCollector Modules { get; private set; }

        //  Add Initial Modules
        public void InitializeCharacter()
        {
            Modules.Profile = (ModuleFactory.CreateModule("ProfileModule"));
            Modules.Race = (ModuleFactory.CreateModule("RaceModule"));
            Modules.Class = (ModuleFactory.CreateModule("ClassModule"));
            Modules.Health = (ModuleFactory.CreateModule("HealthModule"));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "STR")));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "DEX")));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "CON")));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "INT")));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "WIS")));
            Modules.AddModule((ModuleFactory.CreateModule("AbilityModule", "CHA")));
        }

        //  Methods
        public void CalculateProperties()
        {
        }

        public bool IsValid()
        {
            if (IsStringMissing((string)Modules.Profile.GetProperty("Name")))
                return false;
            if (IsStringMissing((string)Modules.Race.GetProperty("Race")))
                return false;
            if (IsStringMissing((string)Modules.Class.GetProperty("Class")))
                return false;

            return true;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }
    }
}
