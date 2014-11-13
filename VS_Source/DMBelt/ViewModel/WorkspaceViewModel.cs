using System;
using System.Windows.Input;

namespace DMBelt.ViewModel
{
    /// <summary>
    /// This ViewModelBase subclass requests to be removed 
    /// from the UI when its CloseCommand executes.
    /// This class is abstract.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        //  Fields
        CommandInterface c_showCommand;
        CommandInterface c_closeCommand;

        //  Constructor

        protected WorkspaceViewModel()
        {
        }

        //  ShowCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to show this workspace in the user interface.
        /// </summary>
        public ICommand ShowCommand
        {
            get
            {
                if (c_showCommand == null)
                    c_showCommand = new CommandInterface(param => this.OnRequestShow());

                return c_showCommand;
            }
        }
        //  RequestShow [event]

        /// <summary>
        /// Raised when this workspace should be shown in the UI.
        /// </summary>
        public event EventHandler RequestShow;

        void OnRequestShow()
        {
            EventHandler handler = this.RequestShow;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }


        //  CloseCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (c_closeCommand == null)
                    c_closeCommand = new CommandInterface(param => this.OnRequestClose());

                return c_closeCommand;
            }
        }
        //  RequestClose [event]

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }


}