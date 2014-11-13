using System;
using DMBelt.ViewModel;

namespace DMBelt.DataAccess
{
    /// <summary>
    /// Event arguments used by CharacterRepository's CharacterDeleted event.
    /// </summary>
    public class CharacterDeletedEventArgs : EventArgs
    {
        public CharacterDeletedEventArgs(CharacterViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public CharacterViewModel ViewModel { get; private set; }
    }
}