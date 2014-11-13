using System.Collections;
using System.Collections.Generic;

namespace DMBelt.Model.Character
{
    class CharacterProperty
    {
        public CharacterProperty(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public List<string> Qualifiers { get; set; }
    }

    class PropertyModifier
    {
        public string PropertyName { get; set; }
        public int Value { get; set; }
        public List<string> Qualifiers { get; set; }
    }
}
