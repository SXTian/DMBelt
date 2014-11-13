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
    /// Represents a character displayed by a View.
    /// </summary>
    public class CharacterViewModel : ViewModelBase
    {
        public CharacterViewModel(Character character, MainWindowViewModel mainWindow)
        {
            m_mainWindow = mainWindow;
            Character = character;
            base.DisplayName = (string)character.Modules.Profile.GetProperty("Name");
        }

        //  Fields
        private MainWindowViewModel m_mainWindow;
        ReadOnlyCollection<CommandViewModel> m_commands;

        public Character Character { get; set; }

        bool m_isSelected;

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
                new CommandViewModel(Resources.AllCharacters_ViewCoreStats, new CommandInterface(param => this.ViewCoreStats())),
                new CommandViewModel(Resources.AllCharacters_ViewSpells, new CommandInterface(param => this.ViewSpells())),
                new CommandViewModel(Resources.AllCharacters_ViewItems, new CommandInterface(param => this.ViewItems())),
                new CommandViewModel(Resources.AllCharacters_DeleteCharacter, new CommandInterface(param => this.DeleteCharacter()))
            };
        }
        public void ViewCoreStats()
        {
            CharacterModulesViewModel vm = new CharacterModulesViewModel(this);
            m_mainWindow.Workspaces.Add(vm);
            m_mainWindow.ActiveWorkspace = vm;
        }

        public void ViewSpells()
        {
            CharacterSpellsViewModel vm = new CharacterSpellsViewModel(this);
            m_mainWindow.Workspaces.Add(vm);
            m_mainWindow.ActiveWorkspace = vm;
        }

        public void ViewItems()
        {
            CharacterItemsViewModel vm = new CharacterItemsViewModel(this);
            m_mainWindow.Workspaces.Add(vm);
            m_mainWindow.ActiveWorkspace = vm;
        }

        public void SaveCharacter()
        {
            m_mainWindow.Repository.AddCharacter(Character);
        }

        public void DeleteCharacter()
        {
            m_mainWindow.Repository.DeleteCharacter(Character, new CharacterDeletedEventArgs(this));
        }

        /// <summary>
        /// Returns true if this Character was created by the user and it has not yet
        /// been saved to the Character repository.
        /// </summary>
        public bool IsNewCharacter
        {
            get { return !m_mainWindow.Repository.ContainsCharacter(Character); }
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
        public string Name
        {
            get { return (string)Character.Modules.Profile.GetProperty("Name"); }
        }
        public bool IsPC
        {
            get { return (bool)Character.Modules.Profile.GetProperty("IsPC"); }
        }
        public string Race
        {
            get { return (string)Character.Modules.Race.GetProperty("Race"); }
        }
        public string Class
        {
            get { return (string)Character.Modules.Class.GetProperty("Class"); }
        }
        public int Experience
        {
            get { return (int)Character.Modules.Class.GetProperty("Experience"); }
        }
    }
}