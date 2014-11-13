using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMBelt.Model.Character.Modules
{
    public class ItemModule : IModule
    {
        //  Constructor
        public ItemModule()
        {
            ModuleName = "ItemModule";
        }
        public ItemModule(string item, int enhancement = 0, string material = "", int quantity = 1)
        {
            ModuleName = "ItemModule";
            Item = item;
            Enhancement = enhancement;
            Material = material;
            Quantity = quantity;
        }

        //  Module name and type, ignored during serialization
        [XmlIgnore]
        public string ModuleName { get; private set; }

        //  Serialized Data
        [XmlAttribute]
        public string Item { get; set; }
        [XmlAttribute]
        public int Enhancement { get; set; }
        [XmlAttribute]
        public string Material { get; set; }
        [XmlAttribute]
        public int Quantity { get; set; }

        //  Accessors
        public object GetProperty(string property)
        {
            switch (property)
            {
                case "Item":
                    return Item;

                case "Enhancement":
                    return Enhancement;

                case "Material":
                    return Material;

                case "Quantity":
                    return Quantity;

                default:
                    System.Diagnostics.Debug.Fail("Unexpected field being access in module 'ItemModule': " + property);
                    return null;
            }
        }

        public void SetProperty(string property, object value)
        {
            switch (property)
            {
                case "Item":
                    Item = (string)value;
                    break;

                case "Enhancement":
                    Enhancement = (int)value;
                    break;

                case "Material":
                    Material = (string)value;
                    break;

                case "Quantity":
                    Quantity = (int)value;
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
    class ItemModuleFactory : IModuleFactory
    {
        public IModule CreateModule()
        {
            return new ItemModule();
        }
        public IModule CreateModule(string item)
        {
            return new ItemModule(item);
        }
        public IModule CreateModule(IModule module)
        {
            ItemModule copy = module as ItemModule;
            return new ItemModule(copy.Item, copy.Enhancement, copy.Material, copy.Quantity);
        }
    }
}
