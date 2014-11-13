using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using DMBelt.DataAccess;
using DMBelt.Model.Character;
using DMBelt.Properties;
using DMBelt.ViewModel.Workspaces;

namespace DMBelt.ViewModel
{
    /// <summary>
    /// The ViewModel for the application's main window.
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        //  Fields
        ReadOnlyCollection<CommandViewModel> m_commands;
        ObservableCollection<WorkspaceViewModel> m_workspaces;
        WorkspaceViewModel m_activeWorkspace;

        CommandInterface c_saveCommand;

        //  Constructor

        public MainWindowViewModel(string characterDataFile)
        {
            base.DisplayName = Resources.MainWindow_DisplayName;
            Repository = new CharacterRepository(characterDataFile);
            ShowAllCharacters();
        }

        public CharacterRepository Repository { get; private set; }

        //  Commands
        public ICommand SaveCommand
        {
            get
            {
                if (c_saveCommand == null)
                    c_saveCommand = new CommandInterface(param => this.Save());

                return c_saveCommand;
            }
        }
        public void Save()
        {
            Repository.Save();
        }

        /// <summary>
        /// Returns a read-only list of commands 
        /// that the UI can display and execute.
        /// </summary>
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
                new CommandViewModel(
                    Resources.ControlPanel_ViewAllCharacters,
                    new CommandInterface(param => this.ShowAllCharacters())),

                new CommandViewModel(
                    Resources.ControlPanel_CreateNewCharacter,
                    new CommandInterface(param => this.CreateNewCharacter()))
            };
        }

        //  Workspaces

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (m_workspaces == null)
                {
                    m_workspaces = new ObservableCollection<WorkspaceViewModel>();
                    m_workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return m_workspaces;
            }
        }

        public WorkspaceViewModel ActiveWorkspace
        {
            get
            {
                return m_activeWorkspace;
            }
            set
            {
                m_activeWorkspace = value;
                this.OnPropertyChanged("ActiveWorkspace");
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                {
                    workspace.RequestShow += this.OnWorkspaceRequestShow;
                    workspace.RequestClose += this.OnWorkspaceRequestClose;
                }

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                {
                    workspace.RequestShow -= this.OnWorkspaceRequestShow;
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
                }
        }

        void OnWorkspaceRequestShow(object sender, EventArgs e)
        {
            ActiveWorkspace = sender as WorkspaceViewModel;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
            ShowAllCharacters();
        }


        //  Private Helpers

        void CreateNewCharacter()
        {
            Character newCharacter = new Character();
            newCharacter.InitializeCharacter();
            CharacterViewModel vm = new CharacterViewModel(newCharacter, this);
            CharacterModulesViewModel workspace = new CharacterModulesViewModel(vm);
            this.Workspaces.Add(workspace);
            ActiveWorkspace = workspace;
        }

        void ShowAllCharacters()
        {
            AllCharactersViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllCharactersViewModel)
                as AllCharactersViewModel;

            if (workspace == null)
            {
                workspace = new AllCharactersViewModel(this);
                this.Workspaces.Add(workspace);
            }

            ActiveWorkspace = workspace;
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }
}