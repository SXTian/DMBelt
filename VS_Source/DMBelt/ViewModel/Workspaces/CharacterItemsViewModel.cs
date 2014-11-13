using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using DMBelt.DataAccess;
using DMBelt.Model.Character;
using DMBelt.Properties;

namespace DMBelt.ViewModel.Workspaces
{
    /// <summary>
    /// A UI wrapper for a Character's Spells.
    /// </summary>
    public class CharacterItemsViewModel : WorkspaceViewModel
    {
        //  Fields
        CharacterViewModel cvm;

        //  Constructor
        public CharacterItemsViewModel(CharacterViewModel viewModel)
        {
            cvm = viewModel;
        }

        public class Equipment
        {
            public Equipment(IModule module)
            {
                m_equip = module;
            }
            IModule m_equip;
            public string Name
            {
                get { return (string)m_equip.GetProperty("Equipment"); }
                set { m_equip.SetProperty("Item", value); }
            }
            public int Enhancement
            {
                get { return (int)m_equip.GetProperty("Enhancement"); }
                set { m_equip.SetProperty("Enhancement", value); }
            }
            public string Material
            {
                get { return (string)m_equip.GetProperty("Material"); }
                set { m_equip.SetProperty("Material", value); }
            }
            public string Slot
            {
                get { return (string)m_equip.GetProperty("Slot"); }
                set { m_equip.SetProperty("Slot", value); }
            }
        }

        public class Item
        {
            public Item(IModule module)
            {
                m_item = module;
            }
            IModule m_item;
            public string Name
            {
                get { return (string)m_item.GetProperty("Item"); }
                set { m_item.SetProperty("Item", value); }
            }
            public int Enhancement
            {
                get { return (int)m_item.GetProperty("Enhancement"); }
                set { m_item.SetProperty("Enhancement", value); }
            }
            public string Material
            {
                get { return (string)m_item.GetProperty("Material"); }
                set { m_item.SetProperty("Material", value); }
            }
            public int Quantity
            {
                get { return (int)m_item.GetProperty("Quantity"); }
                set { m_item.SetProperty("Quantity", value); }
            }
        }


        public ObservableCollection<Equipment> EquipmentList
        {
            get
            {
                ObservableCollection<Equipment> result = new ObservableCollection<Equipment>();
                foreach (IModule module in cvm.Character.Modules.Equipment)
                    result.Add(new Equipment(module));
                return result;
            }
            set { }
        }

        public ObservableCollection<Item> ItemList
        {
            get
            {
                ObservableCollection<Item> result = new ObservableCollection<Item>();
                foreach (IModule module in cvm.Character.Modules.Items)
                        result.Add(new Item(module));
                return result;
            }
            set { }
        }

        public override string DisplayName
        {
            get
            {
                return "~ITEMS~\n" + (string)cvm.Character.Modules.Profile.GetProperty("Name");
            }
        }
    }
}