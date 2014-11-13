using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using DMBelt.DataAccess;
using DMBelt.Model.Character;
using DMBelt.Properties;
using DMBelt.ViewModel.Workspaces;

namespace DMBelt.ViewModel
{
    /// <summary>
    /// Represents a Spell displayed by a View.
    /// </summary>
    public class SpellViewModel : ViewModelBase
    {
        public SpellViewModel(IModule module)
        {
            base.DisplayName = (string)module.GetProperty("Spell");
            m_module = module;
        }

        //  Fields
        private IModule m_module;
        ReadOnlyCollection<CommandViewModel> m_commands;

        bool m_isSelected;

        public string SpellName
        {
            get { return (string)m_module.GetProperty("Spell"); }
            set { m_module.SetProperty("Spell", value); }
        }
        public string Metamagic
        {
            get { return (string)m_module.GetProperty("Metamagic"); }
            set { m_module.SetProperty("Metamagic", value); }
        }
        public int Level
        {
            get { return (int)m_module.GetProperty("Level"); }
            set { m_module.SetProperty("Level", value); }
        }
        public int Quantity
        {
            get { return (int)m_module.GetProperty("Quantity"); }
            set { m_module.SetProperty("Quantity", value); }
        }

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (m_commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    m_commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return m_commands;
            }
        }

        List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
		     {
                 // 'Spells Known' Commands
                new CommandViewModel(Resources.Spell_AddToPrepared, new CommandInterface(param => this.AddToPrepared())),
                new CommandViewModel(Resources.Spell_RemoveSpell, new CommandInterface(param => this.RemoveSpell())),

                //  'Spells Prepared' Commands
                new CommandViewModel(Resources.Spell_AddMetamagic, new CommandInterface(param => this.AddMetamagic())),
                new CommandViewModel(Resources.Spell_RemovePrepared, new CommandInterface(param => this.RemovePrepared()))
            };
        }
        public void AddToPrepared()
        {

        }

        public void RemoveSpell()
        {
        }

        public void AddMetamagic()
        {
        }

        public void RemovePrepared()
        {
        }

        /// <summary>
        /// Gets/sets whether this Character is selected in the UI.
        /// </summary>
        public bool IsSelected
        {
            get { return m_isSelected; }
            set
            {
                if (value == m_isSelected)
                    return;

                m_isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }
    }
}