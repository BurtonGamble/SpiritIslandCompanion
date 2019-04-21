using System.Windows;

namespace SpiritIslandCompanion
{
    /// <summary>
    /// Interaction logic for FrmAbout.xaml
    /// </summary>
    public partial class FrmAbout : Window
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBlkAbout.Text = "Spirit Island Companion App" +
                "\n© 2018 Burton Gamble All Rights Reserved." +
                "\n\nCreated and released under implicit permission based on" +
                "\n'Creating your own game elements' as specified at" +
                "\nhttps://querki.net/u/darker/spirit-island-faq/#!.9v5ka4u" +
                "\n\nAll artwork © its respective rights holder." +
                "\n\nSpirit Island Board Game & all other game related content" +
                "\n© Greater Than Games.";
        }
    }
}