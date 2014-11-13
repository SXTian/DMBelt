using System.Text.RegularExpressions;

namespace DMBelt.View
{
    public partial class CharacterModulesView : System.Windows.Controls.UserControl
    {
        public CharacterModulesView()
        {
            InitializeComponent();
        }
        //  Logic for not allowing the user to enter non-numbers
        private void intTxt_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
    }
}