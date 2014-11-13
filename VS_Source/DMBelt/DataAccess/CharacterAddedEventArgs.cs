using System;
using DMBelt.Model.Character;

namespace DMBelt.DataAccess
{
    /// <summary>
    /// Event arguments used by CharacterRepository's CharacterAdded event.
    /// </summary>
    public class CharacterAddedEventArgs : EventArgs
    {
        public CharacterAddedEventArgs(Character newCharacter)
        {
            this.NewCharacter = newCharacter;
        }

        public Character NewCharacter { get; private set; }
    }
}