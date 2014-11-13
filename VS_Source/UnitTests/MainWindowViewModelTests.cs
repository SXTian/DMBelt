using System.Linq;
using System.Windows.Data;
using DMBelt.Properties;
using DMBelt.ViewModel;
using DMBelt.ViewModel.Workspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        public MainWindowViewModelTests()
        {
            mainWindow = new MainWindowViewModel("../Data/Character.xml");
        }

        private MainWindowViewModel mainWindow;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() { }


        // NOTE: In order to access the auto-generated Resources class in the main assembly, I had to change the
        // Custom Tool associated with Resources.resx from ResXFileCodeGenerator to PublicResXFileCodeGenerator.

        [TestMethod]
        public void TestViewAllCharacters()
        {
            CommandViewModel commandVM = mainWindow.Commands.First(cvm => cvm.DisplayName == Resources.ControlPanel_ViewAllCharacters);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(mainWindow.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is AllCharactersViewModel, "Invalid current item.");
        }

        [TestMethod]
        public void TestCreateNewCharacters()
        {
            CommandViewModel commandVM = mainWindow.Commands.First(cvm => cvm.DisplayName == Resources.ControlPanel_CreateNewCharacter);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(mainWindow.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is CharacterModulesViewModel, "Invalid current item.");
        }

        [TestMethod]
        public void TestCannotViewAllCharactersTwice()
        {
            CommandViewModel commandVM = mainWindow.Commands.First(cvm => cvm.DisplayName == Resources.ControlPanel_ViewAllCharacters);
            // Tell the ViewModel to show all customers twice.
            commandVM.Command.Execute(null);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(mainWindow.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is AllCharactersViewModel, "Invalid current item.");
            Assert.IsTrue(mainWindow.Workspaces.Count == 1, "Invalid number of view models.");
        }

        [TestMethod]
        public void TestCloseAllCharactersWorkspace()
        {
            // Create the MainWindowViewModel, but not the MainWindow.
            MainWindowViewModel target = mainWindow;

            Assert.AreEqual(0, target.Workspaces.Count, "Workspaces isn't empty.");

            // Find the command that opens the "All Customers" workspace.
            CommandViewModel commandVM =
                target.Commands.First(cvm => cvm.DisplayName == Resources.ControlPanel_ViewAllCharacters);

            // Open the "All Customers" workspace.
            commandVM.Command.Execute(null);
            Assert.AreEqual(1, target.Workspaces.Count, "Did not create viewmodel.");

            // Ensure the correct type of workspace was created.
            var allCustomersVM = target.Workspaces[0] as AllCharactersViewModel;
            Assert.IsNotNull(allCustomersVM, "Wrong viewmodel type created.");

            // Tell the "All Customers" workspace to close.
            allCustomersVM.CloseCommand.Execute(null);
            Assert.AreEqual(0, target.Workspaces.Count, "Did not close viewmodel.");
        }
    }
}