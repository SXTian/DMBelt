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
    public class CharacterSpellsViewModel : WorkspaceViewModel
    {
        //  Fields
        CharacterViewModel cvm;
        CommandInterface c_addSpellCommand;

        //  Constructor
        public CharacterSpellsViewModel(CharacterViewModel viewModel)
        {
            cvm = viewModel;
        }

        public ObservableCollection<SpellViewModel> SpellList
        {
            get
            {
                ObservableCollection<SpellViewModel> result = new ObservableCollection<SpellViewModel>();
                foreach (IModule module in cvm.Character.Modules.PreparedSpells)
                {
                    if ((string)module.GetProperty("Metamagic") == "")
                        result.Add(new SpellViewModel(module));
                }
                return result;
            }
            set { }
        }

        public ObservableCollection<SpellViewModel> PreparedSpellList
        {
            get
            {
                ObservableCollection<SpellViewModel> result = new ObservableCollection<SpellViewModel>();
                foreach (IModule module in cvm.Character.Modules.PreparedSpells)
                {
                    if ((int)module.GetProperty("Quantity") > 0)
                        result.Add(new SpellViewModel(module));
                }
                return result;
            }
            set { }
        }

        //  Current Textbox Text
        public string currentSpellName { get; set; }
        public int currentSpellLevel { get; set; }

        //  Add Feat Command
        public ICommand AddSpellCommand
        {
            get
            {
                if (c_addSpellCommand == null)
                {
                    c_addSpellCommand = new CommandInterface(
                        param => this.AddSpell(),
                        param => this.CanAddSpell());
                }
                return c_addSpellCommand;
            }
        }
        public void AddSpell()
        {
            IModule spell = ModuleFactory.CreateModule("PreparedSpellModule", currentSpellName);
            spell.SetProperty("Level", currentSpellLevel);
            cvm.Character.Modules.AddModule(spell);
            OnPropertyChanged("SpellList");
        }
        public bool CanAddSpell()
        {
            return !IsStringMissing(currentSpellName);
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        public override string DisplayName
        {
            get
            {
                return "~SPELLS~\n" + (string)cvm.Character.Modules.Profile.GetProperty("Name");
            }
        }
    }
}