using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using DMBelt.DataAccess;
using DMBelt.Model.Character;
using DMBelt.Properties;

namespace DMBelt.ViewModel.Workspaces
{
    /// <summary>
    /// Represents a container of CharacterModulesViewModel objects
    /// that has support for staying synchronized with the
    /// CharacterRepository.
    /// </summary>
    public class AllCharactersViewModel : WorkspaceViewModel
    {
        //  Fields
        readonly MainWindowViewModel m_mainWindow;

        //  Constructor
        public AllCharactersViewModel(MainWindowViewModel mainWindow)
        {
            base.DisplayName = Resources.TabLabel_AllCharacters;

            m_mainWindow = mainWindow;

            // Subscribe for notifications of when a new Character is saved.
            m_mainWindow.Repository.CharacterAdded += this.OnCharacterAddedToRepository;

            // Subscribe for notifications of when a Character is deleted.
            m_mainWindow.Repository.CharacterDeleted += this.OnCharacterDeletedFromRepository;

            // Populate the AllCharacters collection with CharacterViewModels.
            this.CreateAllCharacters();
        }



        void CreateAllCharacters()
        {
            List<CharacterViewModel> all =
                (from character in m_mainWindow.Repository.GetCharacters()
                 select new CharacterViewModel(character, m_mainWindow)).ToList();

            foreach (CharacterViewModel cvm in all)
                cvm.PropertyChanged += this.OnCharacterViewModelPropertyChanged;

            this.AllCharacters = new ObservableCollection<CharacterViewModel>(all);
            this.AllCharacters.CollectionChanged += this.OnCollectionChanged;
        }

        //Public Interface

        /// <summary>
        /// Returns a collection of all the CharacterModulesViewModel objects.
        /// </summary>
        public ObservableCollection<CharacterViewModel> AllCharacters { get; private set; }

        //  Base Override
        protected override void OnDispose()
        {
            foreach (CharacterViewModel cvm in this.AllCharacters)
                cvm.Dispose();

            this.AllCharacters.Clear();
            this.AllCharacters.CollectionChanged -= this.OnCollectionChanged;

            m_mainWindow.Repository.CharacterAdded -= this.OnCharacterAddedToRepository;
        }

        //  Event Handling

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (CharacterViewModel vm in e.NewItems)
                    vm.PropertyChanged += this.OnCharacterViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (CharacterViewModel vm in e.OldItems)
                    vm.PropertyChanged -= this.OnCharacterViewModelPropertyChanged;
        }

        void OnCharacterViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";
            // Make sure that the property name we're referencing is valid.
            (sender as CharacterViewModel).VerifyPropertyName(IsSelected);
        }

        void OnCharacterAddedToRepository(object sender, CharacterAddedEventArgs e)
        {
            var viewModel = new CharacterViewModel(e.NewCharacter, m_mainWindow);
            this.AllCharacters.Add(viewModel);
        }

        void OnCharacterDeletedFromRepository(object sender, CharacterDeletedEventArgs e)
        {
            this.AllCharacters.Remove(e.ViewModel);
        }

    }
}