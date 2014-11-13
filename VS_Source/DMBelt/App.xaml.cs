using System;
using System.Windows;
using System.Windows.Markup;
using DMBelt.ViewModel;

namespace DMBelt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            MainWindowViewModel mw = new MainWindowViewModel("../Debug/Data/Characters.xml");

            // When the ViewModel asks to be closed,
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                mw.RequestClose -= handler;
                window.Close();
            };
            mw.RequestClose += handler;

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.DataContext = mw;

            window.Show();
        }
    }
}
