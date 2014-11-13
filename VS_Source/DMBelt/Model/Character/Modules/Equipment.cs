using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class EquipmentModule : IModule
    {
        //  Constructor
        public EquipmentModule()
        {
            ModuleName = "EquipmentModule";
        }
        public EquipmentModule(string slot, string equipment = "", int enhancement = 0, string material = "")
        {
            ModuleName = "EquipmentModule";
            Slot = slot;
            Equipment = equipment;
            Enhancement = enhancement;
            Material = material;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Equipment { get; set; }
        [XmlAttribute]
        public int Enhancement { get; set; }
        [XmlAttribute]
        public string Material { get; set; }
        [XmlAttribute]
        public string Slot { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Equipment":
                    return Equipment;

                case "Enhancement":
                    return Enhancement;

                case "Material":
                    return Material;

                case "Slot":
                    return Slot;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'Race': " + property);
                    return null;
            }
        }

        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Equipment":
                    Equipment = (string)value;
                    break;

                case "Enhancement":
                    Enhancement = (int)value;
                    break;

                case "Material":
                    Material = (string)value;
                    break;

                case "Slot":
                    Slot = (string)value;
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
    class EquipmentModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new EquipmentModule();
        }
        public IModule CreateModule(string slot)
        {
            return new EquipmentModule(slot);
        }
        public IModule CreateModule(IModule module)
        {
            EquipmentModule copy = module as EquipmentModule;
            return new EquipmentModule(copy.Slot, copy.Equipment, copy.Enhancement, copy.Material);
        }
    }
}
