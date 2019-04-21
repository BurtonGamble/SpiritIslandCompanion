using System.Windows;
using System.Windows.Media;

namespace SpiritIslandCompanion
{
    /// <summary>
    /// Interaction logic for FrmCardView.xaml
    /// </summary>
    public partial class FrmCardView : Window
    {
        private ImageSource _showCard;

        public FrmCardView()
        {
            InitializeComponent();
        }

        public ImageSource ShowCard
        {
            get { return _showCard; }
            set { _showCard = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imgMain.Source = ShowCard;
            Width = imgMain.Source.Width;
            Height = imgMain.Source.Height;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}